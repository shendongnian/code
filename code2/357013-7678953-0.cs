            string spName = "DELETE_TABLE_S1";
            string methodText = "";
            string[] methods = theCompleteStringWithAllMethods.Split(new string[] { "public"     }, StringSplitOptions.None);
            for (int ii = 0; ii < methods.Length; ii++)
            {
                if (methods[ii].Contains("SpName=" + spName))
                {
                    methodText = "public " + methods[ii];
                    break;
                }
            }
