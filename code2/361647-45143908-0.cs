    class Program
    {
        static List<string> result = new List<string>();
        public void FindAllSubsets(int[] subsets)
        {
            int n = subsets.Length;
            for (int i = 0; i < n; i++)
            {
                FindAllSubset(subsets[i]);
            }
        }
        public void FindAllSubset(int i)
        {
            ExpandAllSubsets(i);
            result.Add(i.ToString());
        }
        public void ExpandAllSubsets(int i )
        {
            List<string> tempSet = new List<string>();
            foreach (var elem in result)
            {
                  string newElem = elem + "-" + i;
                  tempSet.Add(newElem);
            }
            AddFromTempSetToResultSet(tempSet);
        }
        public void AddFromTempSetToResultSet(List<string> tempSet)
        {
            result.AddRange(tempSet);
        }
        public void PrintResult()
        {
            foreach (var elem in result)
            {
                Console.WriteLine(elem);
            }
        }
     public  static void Main(string[] args)
        {
            Program pr = new Program();
            int[] arr = new int[]{ 1,2,3,4,5 };
            pr.FindAllSubsets(arr);
            PrintResult()
            Console.ReadLine();
        }
}
