        static void Main(string[] args)
        {
            string input = "AB_C + ABC_D/ * ABC_DE/ =ABC.AVO";
            string operators = "*+=";
            List<string> list1 = new List<string>(input.Split(operators.ToArray(), StringSplitOptions.RemoveEmptyEntries));
            for(int i =0; i<list1.Count; i++)
            {
                list1[i] = list1[i].Trim();
            }
            List<string> list2 = new List<string>();
            for(int i = 0; i < input.Length; i++)
            {
                if(operators.Contains(input.Substring(i,1)))
                {
                    list2.Add(input.Substring(i, 1));
                }
            }
            Console.WriteLine("list1 = " + String.Join(",", list1.ToArray()));
            Console.WriteLine("list2 = " + String.Join(",", list2.ToArray()));
            Console.ReadLine();
        }
