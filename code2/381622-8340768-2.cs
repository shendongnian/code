    static string RemoveCstyleComments(string strInput)
            {
                string strPattern = @"/[*][\w\d\s]+[*]/";
                //strPattern = @"/\*.*?\*/"; // Doesn't work
                //strPattern = "/\\*.*?\\*/"; // Doesn't work
                //strPattern = @"/\*([^*]|[\r\n]|(\*+([^*/]|[\r\n])))*\*+/ "; // Doesn't work
                //strPattern = @"/\*([^*]|[\r\n]|(\*+([^*/]|[\r\n])))*\*+/ "; // Doesn't work
    
                // http://stackoverflow.com/questions/462843/improving-fixing-a-regex-for-c-style-block-comments
                strPattern = @"/\*(?>(?:(?>[^*]+)|\*(?!/))*)\*/";  // Works !
    
                string strOutput = System.Text.RegularExpressions.Regex.Replace(strInput, strPattern, string.Empty, System.Text.RegularExpressions.RegexOptions.Multiline);
                Console.WriteLine(strOutput);
                return strOutput;
            } // End Function RemoveCstyleComments
  
    
    
    
            static string ReplaceVariables(string strInput)
        {
            string strPattern = @"var\s+providers_large(\s+)?=(\s+)?{(\s+)?";
            strInput = System.Text.RegularExpressions.Regex.Replace(strInput, strPattern, "\"providers_large\" : {" + Environment.NewLine, System.Text.RegularExpressions.RegexOptions.Multiline);
            strPattern = @"(\s+)?var\s+providers_small(\s+)?=(\s+)?{(\s+)?";
            strInput = System.Text.RegularExpressions.Regex.Replace(strInput, strPattern, ",   \"providers_small\" : {" + Environment.NewLine, System.Text.RegularExpressions.RegexOptions.Multiline);
            strPattern = @"}(\s+)?;(\s+)?";
            strInput = System.Text.RegularExpressions.Regex.Replace(strInput, strPattern, "}" + Environment.NewLine, System.Text.RegularExpressions.RegexOptions.Multiline);
            strPattern = @"$(\s+)?(\w+)(\s+)?:(\s+)?{";
            strInput = System.Text.RegularExpressions.Regex.Replace(strInput, strPattern, "\"$2\" : {", System.Text.RegularExpressions.RegexOptions.Multiline);
            strPattern = @"name(\s+)?:(\s+)?'";
            strInput = System.Text.RegularExpressions.Regex.Replace(strInput, strPattern, "\"name\" : '", System.Text.RegularExpressions.RegexOptions.Multiline);
            strPattern = @"url(\s+)?:(\s+)?'";
            strInput = System.Text.RegularExpressions.Regex.Replace(strInput, strPattern, "\"url\" : '", System.Text.RegularExpressions.RegexOptions.Multiline);
            strPattern = @"label(\s+)?:(\s+)?'";
            strInput = System.Text.RegularExpressions.Regex.Replace(strInput, strPattern, "\"label\" : '", System.Text.RegularExpressions.RegexOptions.Multiline);
            strInput = strInput.Replace("'", "\"");
            strPattern = "openid\\.locale.*";
            //strInput = System.Text.RegularExpressions.Regex.Replace(strInput, strPattern, "", System.Text.RegularExpressions.RegexOptions.Multiline);
            strInput = System.Text.RegularExpressions.Regex.Replace(strInput, strPattern, "", System.Text.RegularExpressions.RegexOptions.Singleline);
            strPattern = null;
            
            /*
            string[] astrTrailingComments = {
                             @"openid\.locale"
                            ,@"openid\.sprite"
                            ,@"openid\.demo_text"
                            ,@"openid\.signin_text"
                            ,@"openid\.image_title"
            };
            foreach (string strThisPattern in astrTrailingComments)
            {
                strInput = System.Text.RegularExpressions.Regex.Replace(strInput, strThisPattern + ".+", "", System.Text.RegularExpressions.RegexOptions.Multiline);
            } // Next strThisPattern
            */
             
            strInput = "{" + strInput + "}";
            //Console.WriteLine(strInput);
            return strInput;
        } // End Function ReplaceVariables
    
    
            static System.Collections.Specialized.NameValueCollection TrySerialize(string strInput)
            {
                strInput = RemoveCstyleComments(strInput);
                strInput = ReplaceVariables(strInput);
    
                System.Collections.Specialized.NameValueCollection nvc = new System.Collections.Specialized.NameValueCollection(StringComparer.OrdinalIgnoreCase);
    
                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                dynamic objScript = js.DeserializeObject(strInput);
                js = null;
                
    
                foreach (dynamic kvp in objScript)
                {
                    dynamic dictValues = kvp.Value;
    
                    //Console.WriteLine(Environment.NewLine);
                    //Console.WriteLine(Environment.NewLine);
                    //Console.WriteLine(kvp.Key);
                    //Console.WriteLine(Environment.NewLine);
    
                    foreach (string strMemberVariable in dictValues.Keys)
                    {
    
                        if(StringComparer.OrdinalIgnoreCase.Equals(kvp.Key,"providers_small"))
                        {
                            nvc.Add("providers_small", strMemberVariable);
                        }
                        
                    
                        if(StringComparer.OrdinalIgnoreCase.Equals(kvp.Key,"providers_large"))
                        {
                            nvc.Add("providers_large", strMemberVariable);
                        }
    
                        //Console.WriteLine(strMemberVariable + ":");
    
                        dynamic MemberVariable = dictValues[strMemberVariable];
                        //Console.WriteLine(MemberVariable.GetType().ToString());
    
                        foreach (string strProperty in MemberVariable.Keys)
                        {
                            //Console.WriteLine(strValue);
                            dynamic objPropertyValue = MemberVariable[strProperty];
    
                            //if (objPropertyValue != null)
                            //Console.WriteLine("     - " + (strProperty + ":").PadRight(8, ' ') + objPropertyValue.ToString());
                        } // Next strProperty
    
                    } // Next strMemberVariable
    
                } // Next kvp
    
                
                // Console.WriteLine("providers large: ");
                // Console.WriteLine(nvc["providers_large"]);
                
                // Console.WriteLine(Environment.NewLine);
                // Console.WriteLine("providers small: ");
                // Console.WriteLine(nvc["providers_small"]);
                
                return nvc;
            } // End Function TrySerialize
    
    
            public static void GetProviders()
            {
                string strContent = System.IO.File.ReadAllText(@"D:\Stefan.Steiger\Downloads\openid-selector-1.3\openid-selector\js\openid-en.js");
                strContent = System.IO.File.ReadAllText(@"D:\Stefan.Steiger\Downloads\openid-selector-1.3\openid-selector\js\openid-ru.js");
                //Console.WriteLine(strContent);
    
                //JavaScriptEngineTest(strContent);
                //GetCurlyValues(strContent);
                System.Collections.Specialized.NameValueCollection nvc = TrySerialize(strContent);
    
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("providers large: ");
                foreach (string strValue in nvc.GetValues("providers_large"))
                {
                    Console.WriteLine("    " + strValue);
                } // Next strValue
    
                //System.Runtime.Serialization.Json.DataContractJsonSerializer dcjs = new System.Runtime.Serialization.Json.DataContractJsonSerializer();
                // The above is bullshit in unadulterated filth. ==> Use System.Web.Extensions instead
    
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("providers small: ");
                foreach (string strValue in nvc.GetValues("providers_small"))
                {
                    Console.WriteLine("    " + strValue);
                } // Next strValue
                
            } // End Sub GetProviders
