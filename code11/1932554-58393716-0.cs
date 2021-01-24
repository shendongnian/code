    class Program
    {
        static void Main(string[] args)
        {
            string initialString = "CN=Test,OU=ABC,OU=Company,DC=CFLA,DC=domain";
            List<string[]> finalList = new List<string[]>();
            string [] firstSplitStringsArray = initialString.Split(',');
            foreach (var item in firstSplitStringsArray)
            {
                string [] secondlySplittedStringsArray = item.Split('=');
                finalList.Add(secondlySplittedStringsArray);
            }
        }
    }
