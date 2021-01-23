    class Program
     {
        static void Main(string[] args)
        {
            string str;
            int i, wrd, l;
            StringBuilder sb = new StringBuilder();
            Console.Write("\n\nCount the total number of words in a string 
            :\n");
            Console.Write("--------------------------------------------------- 
            ---\n");
            Console.Write("Input the string : ");
            str = Console.ReadLine();
            l = 0;
            wrd = 1;
      
            foreach (var a in str)
            {
                sb.Append(a);
                if (str[l] == ' ' || str[l] == '\n' || str[l] == '\t')
                {
                    wrd++;
                }
                l++;
            }
            
            Console.WriteLine(sb.Replace(' ', '\n'));
            Console.Write("Total number of words in the string is : {0}\n", 
            wrd);
            Console.ReadLine();
     }
