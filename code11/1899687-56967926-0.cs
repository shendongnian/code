 C#
//find a string which is end with string1 and start with string2
      static void Main(string[] args)
        {
            var string1 = @"C:/GII/gii_db/DownTime/EMEA";
            var string2 = @"DownTime/EMEA/APPS_GLOBAL/Tables/XXG_CHUB_ADDRESS_T.SQL";
            string result = "";
            int length = string1.Length;
            int index = 1;
            for (int i = 0; i < length; i++)
            {
                string temp = string1.Substring(length - i - 1, index++);
                if (string2.StartsWith(temp))
                {
                    result = temp;
                }
                Console.WriteLine(temp);
            }
            Console.WriteLine($"result:{result}");
            ReadLine();
        }
