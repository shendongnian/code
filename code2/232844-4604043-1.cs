class CodeChanger
{
    private Dictionary<string, Webmethod> webMethodDictionary;
    public CodeChanger()
    {
        webMethodDictionary = new Dictionary<string, Webmethod>();
    }
    public void ChangeCode(string oldFilePath, string newFilePath)
    {
        StringBuilder newFileContents = new StringBuilder();
        StringBuilder webserviceMethodContents = new StringBuilder();
        Encoding iso88591Encoding = Encoding.GetEncoding("ISO-8859-1");
        string readLine;
        using (StreamReader streamReader = new StreamReader(oldFilePath, iso88591Encoding))
        {
            while ((readLine = streamReader.ReadLine()) != null)
            {
                if (!string.IsNullOrEmpty(readLine.Trim()))
                {
                    if (string.Equals(readLine, "[Webmethod]"))
                    {
                        // Read the next line - method signature
                        if ((readLine = streamReader.ReadLine()) != null)
                        {
                            readLine = readLine.Trim();
                            if (readLine.StartsWith("public void"))
                            {
                                string methodName = readLine.Split(new char[] { ' ' })[2];
                                Webmethod webMethod = new Webmethod(methodName);
                                webMethodDictionary.Add(methodName, webMethod);
                                // Process parameters
                                ProcessParameters(readLine, methodName, webMethod);
                                // Process Body
                                if ((readLine = streamReader.ReadLine()) != null)
                                {
                                    StringBuilder methodBody = new StringBuilder();
                                    readLine = readLine.Trim();
                                    if (string.Equals(readLine, "{"))
                                    {
                                        int bracketCounter = 1;
                                        while ((readLine = streamReader.ReadLine()) != null)
                                        {
                                            if (string.Equals(readLine.Trim(), "}"))
                                            {
                                                bracketCounter--;
                                            }
                                            else if (string.Equals(readLine.Trim(), "{"))
                                            {
                                                bracketCounter++;
                                            }
                                            if (bracketCounter != 0)
                                            {
                                                methodBody.AppendLine(readLine);
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                        webMethod.AddBody(methodBody.ToString());
                                    }
                                }
                                newFileContents.AppendLine(GenerateNewWebmethods(webMethod));
                            }
                        }
                    }
                    else
                    {
                        newFileContents.AppendLine(readLine);
                    }
                }
                else
                {
                    newFileContents.AppendLine();
                }
            }
        }
        using (StreamWriter writer = new StreamWriter(newFilePath, false, iso88591Encoding))
        {
            writer.Write(newFileContents.ToString());
        }
    }
    private static void ProcessParameters(string readLine, string methodName, Webmethod webMethod)
    {
        int positionOpenBrackets = string.Concat("public void ", methodName, " ").Length;
        string parametersString = readLine.Substring(positionOpenBrackets).Trim();
        parametersString = parametersString.TrimStart(new char[] { '(' });
        parametersString = parametersString.TrimEnd(new char[] { ')' });
        string[] parameters = parametersString.Split(new char[] { ',' });
        foreach (string parameter in parameters)
        {
            string[] splitParameters = parameter.Trim().Split(new char[] { ' ' });
            webMethod.AddParameter(splitParameters[0].Trim(), splitParameters[1].Trim());
        }
    }
    private string GenerateNewWebmethods(Webmethod webmethod)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(GenerateInternal(webmethod));
        stringBuilder.AppendLine(GenerateBegin(webmethod));
        stringBuilder.Append(GenerateEnd(webmethod));
        return stringBuilder.ToString();
    }
    private string GenerateInternal(Webmethod webmethod)
    {
        StringBuilder stringBuilder = new StringBuilder();
        string parametersString = GenerateParameterString(webmethod);
        stringBuilder.AppendLine(string.Format("public void Internal{0} ({1}, AsyncCallback callback)",
            webmethod.Name, parametersString.Trim().TrimEnd(',')));
        stringBuilder.AppendLine("{");
        stringBuilder.Append(webmethod.Body);
        stringBuilder.AppendLine("}");
        return stringBuilder.ToString();
    }
    private string GenerateEnd(Webmethod webmethod)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(string.Format("public void End{0} (IAsyncResult asyncResult)", webmethod.Name));
        stringBuilder.AppendLine("{");
        stringBuilder.AppendLine("//Set return values");
        stringBuilder.Append("}");
        return stringBuilder.ToString();
    }
    private string GenerateBegin(Webmethod webmethod)
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("[Webmethod]");
        string parametersString = GenerateParameterString(webmethod);
        stringBuilder.AppendLine(string.Format("public void Begin{0} ({1}, AsyncCallback callback, object asyncState)",
            webmethod.Name, parametersString.Trim().TrimEnd(',')));
        stringBuilder.AppendLine("{");
        stringBuilder.AppendLine("//Queue InternalMyWebservice in a threadpool");
        stringBuilder.AppendLine("}");
        return stringBuilder.ToString();
    }
    private static string GenerateParameterString(Webmethod webmethod)
    {
        StringBuilder parametersStringBuilder = new StringBuilder();
        foreach (MethodParameter parameter in webmethod.Parameters)
        {
            string parameterString = string.Concat(parameter.Type, " ", parameter.Name, ", ");
            parametersStringBuilder.Append(parameterString);
        }
        return parametersStringBuilder.ToString();
    }
}
class Webmethod
{
    public IList<MethodParameter> Parameters { get; private set; }
    public string Name { get; private set; }
    public string Body { get; private set; }
    public Webmethod(string name)
    {
        Parameters = new List<MethodParameter>();
        Name = name;
    }
    public void AddParameter(string paramType, string paramName)
    {
        MethodParameter methodParameter = new MethodParameter
                                            {
                                                Type = paramType,
                                                Name = paramName
                                            };
        Parameters.Add(methodParameter);
    }
    public void AddBody(string body)
    {
        Body = body;
    }
}
class MethodParameter
{
    public string Type { get; set; }
    public string Name { get; set; }
}
