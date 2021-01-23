    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter the first string.");
             
                string str = Console.ReadLine(); ;
                string replacestr = Regex.Replace(str, "[^a-zA-Z0-9_]+", " ");
           
      
                Console.WriteLine("Please enter the second string.");
                string str1 = Console.ReadLine(); ;
                string replacestr1 = Regex.Replace(str1, "[^a-zA-Z0-9_]+", " ");
            
                
           
                if (replacestr.Length == replacestr1.Length)
                {
                    char[] cFirst = replacestr.ToLower().ToCharArray();
                    char[] cSecond = replacestr1.ToLower().ToCharArray();
                    Array.Sort<char>(cFirst);
                    Array.Sort<char>(cSecond);
                    if ((new string(cFirst)).Equals((new string(cSecond))))
                        Console.WriteLine("Both String Same");
                    else
                        Console.WriteLine("Both String Not Same");
                }
                else
                    Console.WriteLine("oopsss, something going wrong !!!! try again");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
