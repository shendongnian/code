    string subjectString = "\n\t\"BLOCK\",\"HEADER-\"\r\n\t\t\"NAME\",\"147430\"\r\n\t\t\"REVISION\",\"0000\"\r\n\t\t\"DATE\",\"11/11/10\"\r\n\t\t\"TIME\",\"10:03:47\"\r\n\t\t\"PMABAR\",\"\"\r\n\t\t\"COMMENT\",\"\"\r\n\t\t\"PTPNAME\",\"0805C\"\r\n\t\t\"CMPNAME\",\"0805C\"\r\n\t\"BLOCK\",\"PRTIDDT-\"\r\n\t\t\"PMAPP\",1\r\n\t\t\"PMADC\",0\r\n\t\t\"ComponentQty\",4\r\n\t\"BLOCK\",\"PRTFORM-\"\r\n\t\t....(more)....";
                Regex regexObj = new Regex(@"^(.*\bDATE\b\D*).*?(\"".*?\bTIME\b\D*).*?(\"".*?\bComponentQty\b\D*)\d+(.*)$", RegexOptions.Singleline);
    
                StringBuilder myResult = new StringBuilder();
                Match matchResults = regexObj.Match(subjectString);
                while (matchResults.Success)
                {
                    for (int i = 1; i < matchResults.Groups.Count; i++)
                    {
                        Group groupObj = matchResults.Groups[i];
                        
                        if (groupObj.Success)
                        {
                            myResult.Append(groupObj.Value);
                            switch (i)
                            {
                                case 1:
                                    myResult.Append("NEW_DATE");
                                    break;
                                case 2:
                                    myResult.Append("NEW_TIME");
                                    break;
                                case 3:
                                    myResult.Append("NEW QTY");
                                    break;
                            }
                        }
                    }
                    matchResults = matchResults.NextMatch();
                }
                Console.WriteLine("Final Result : \n\n\n{0}", myResult.ToString());
