    private string ReadEmail(string EmailScript)
    {
      string EncriptedEmail = "";
      string dataPart = "";
      dataPart = EmailScript.Substring(0, EmailScript.IndexOf("document.write")).Replace("//<![CDATA[\r", "").Replace("\"", "").Replace("\r\n","");
      EncriptedEmail = EmailScript.Replace("\"","");
      EncriptedEmail = EncriptedEmail.Substring(EncriptedEmail.IndexOf("'> + "), EncriptedEmail.IndexOf(" + </a>") - EncriptedEmail.IndexOf("'> +")).Replace("'> +", "").Trim();
      string[] requiredVariables = EncriptedEmail.Split('+');
      List<string> ExtractedDataFromRaw = new List<string>();
      string email = "";
      foreach (string variable in requiredVariables)
      {
        string temp = dataPart.Substring(dataPart.IndexOf(variable),dataPart.Length-dataPart.IndexOf(variable)).Replace(" ","");
        string tempValueofVariable = temp.Substring(0, temp.IndexOf(";"));
        tempValueofVariable = tempValueofVariable.Substring(tempValueofVariable.IndexOf("="), tempValueofVariable.Length - temp.IndexOf("=")).Replace("=","");
        if (tempValueofVariable.Contains("String.fromCharCode"))
        {
          tempValueofVariable = GetCharacterFromASCII(tempValueofVariable.Replace("String.fromCharCode(", "").Replace(")", ""));
        }
        ExtractedDataFromRaw.Add(tempValueofVariable.Replace("'",""));
        email += tempValueofVariable.Replace("'", "");
        }
        return email;
     }
     private string GetCharacterFromASCII(string value)
     {
        int result = 0;
        int.TryParse(value, out result);
        return char.ConvertFromUtf32(result);
     }
