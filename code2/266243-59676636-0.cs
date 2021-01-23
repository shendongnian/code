        static void Main(string[] args)
        {
            string str = "Hi how are you";
            char[] char_arr= str.ToCharArray();
            string finalstr = "";           
            string eachwords = "";
            string tempreverseword = "";
            int char_length = char_arr.Length;
            for (int i = 0; i < char_arr.Length; i++)
            {
                if (char_arr[i].ToString() == " " || i == char_length-1)
                {
                    if (i == char_length - 1)
                    {
                        eachwords += char_arr[i] + "";
                    }                   
                    char[] revchar_arr = eachwords.ToCharArray();
                    for (int j = revchar_arr.Length-1; j >=0; j--)
                    {
                        tempreverseword += revchar_arr[j];
                    }
                    finalstr += tempreverseword+" ";
                    tempreverseword = "";                    
                    eachwords = "";
                }               
                else
                {
                    eachwords += char_arr[i] + "";
                }               
            }
            Console.WriteLine(finalstr);
            Console.ReadKey();
        }
