     private static void myfun()
            {
                string mystring = "thiTHISThiss This THIS THis tThishiThiss. Box";
                var regex = new Regex("this", RegexOptions.IgnoreCase);
                mystring = regex.Replace(mystring, "");
                string[] str = mystring.Split(' ');
                for (int i = 0; i < str.Length; i++)
                {
                    if (regex.IsMatch(str[i].ToString()))
                    {
                        mystring = mystring.Replace(str[i].ToString(), string.Empty);
                        
                    }
                }
                Console.WriteLine(mystring);
            }
