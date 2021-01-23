       static void Main(string[] args)
        {
            Console.Write("\nLINQ : Find the uppercase words in a string : ");
            Console.Write("\n----------------------------------------------\n");
            string strNew;
            Console.Write("Input the string : ");
            strNew = Console.ReadLine();
            //string[] newStr = strNew.Split(' ');
            var ucWord = WordFilt(strNew);
            Console.Write("\nThe UPPER CASE words are :\n ");
            foreach (string strRet in ucWord)
            {
                Console.WriteLine(strRet);
            }
            Console.ReadLine();
        }
      static IEnumerable<string> WordFilt(string mystr)
        {
            var upWord =  mystr.Split(' ')
            .Where(x=> !string.IsNullOrEmpty(x) && char.IsUpper(x[0]));
         return upWord;
        }
