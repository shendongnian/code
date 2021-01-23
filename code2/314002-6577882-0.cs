    Uri uri = new Uri(_Url + "?wsdl");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AllowAutoRedirect = true;
            request.PreAuthenticate = false;
            if (_User.Length > 0)
            {
                request.UseDefaultCredentials = false;
                request.Credentials = new NetworkCredential(_User, _Password, _Domain);
            }
            WebResponse response = null;
            
            try
            {
                response = request.GetResponse();
            }
            catch (System.Net.WebException wex)
            {
                response = wex.Response;
            }
            catch (Exception ex)
            {
            }
            
            Stream requestStream = response.GetResponseStream();
            ServiceDescription sd = ServiceDescription.Read(requestStream);
            _ReferenceName = _Namespace + "." + sd.Services[0].Name;
            ServiceDescriptionImporter Importer = new ServiceDescriptionImporter();
            Importer.AddServiceDescription(sd, string.Empty, string.Empty);
            Importer.ProtocolName = "Soap12";
            Importer.CodeGenerationOptions = CodeGenerationOptions.GenerateProperties;
            CodeNamespace nameSpace = new CodeNamespace(_Namespace);
            CodeCompileUnit ccu = new CodeCompileUnit();
            ccu.Namespaces.Add(nameSpace);
            ServiceDescriptionImportWarnings warnings = Importer.Import(nameSpace, ccu);
            if (warnings == 0)
            {
                StringWriter sw = new StringWriter(System.Globalization.CultureInfo.CurrentCulture);
                Microsoft.CSharp.CSharpCodeProvider prov = new Microsoft.CSharp.CSharpCodeProvider();
                CodeGeneratorOptions options = new CodeGeneratorOptions();
                options.BlankLinesBetweenMembers = false;
                options.BracingStyle = "C";
                prov.GenerateCodeFromNamespace(nameSpace, sw, options);
                _ProxySource = sw.ToString();
                sw.Close();
            }
