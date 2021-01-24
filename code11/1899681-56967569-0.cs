           {
                 string string1 =  "C:/GII/gii_db/DownTime/EMEA";
                 string string2 = "DownTime/EMEA/APPS_GLOBAL/Tables/XXG_CHUB_ADDRESS_T.SQL";
                 string[] splitStr1 = string1.Split(new char[] { '/' });
                 string[] splitStr2 = string2.Split(new char[] { '/' });
                 if ((splitStr1[splitStr1.Length - 2] == splitStr2[0]) && (splitStr1[splitStr1.Length - 1] == splitStr2[1]))
                 {
                     Console.WriteLine("Matched");
                 }
       
