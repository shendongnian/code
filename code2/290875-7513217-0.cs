        private static string formatStringToSQLForFullTEXTSEARCH(string subject)
        {
                    string[] subArray  = subject.Trim().Split(' ');
                    string newSubject  = "";            
                    newSubject = "";
                    if (subArray != null && subArray.Length > 0)
                    {
                        newSubject = "'" + subArray[0] + "'";
                        for (int i = 1; i < subArray.Length; i++)
                        {
                            newSubject += " and '" + subArray[i]+"'";
                        }
                    }
        return newSubject;
        }
