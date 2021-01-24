    class Program
    {
        static string temp = string.Empty;
        static void Main(string[] args)
        {
            string word = "Hello World";
            var words = word.Split(' ');
            var result = ReverseWords(words);
            Console.Write(result);
            Console.ReadKey();
        }
        static string ReverseWords(string[] words)
        {
            var reversedList = new List<string>();
            foreach (var word in words)
            {
                temp = string.Empty;
                reversedList.Add(Rev(word, 1));
                reversedList.Add(" ");
            }
            return string.Join("", reversedList);
        }
        static string Rev(string str, int count)
        {
            if (str[0] == str[str.Length - count])
            {
                return temp += str[0];
            }
            return temp += Rev(str.Substring(count), count++) + str[0];
        }
    }
