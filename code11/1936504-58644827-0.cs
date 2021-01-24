    Random rand = new Random();
    List<int> ints = new List<int>();
    for (int i = 0; i < 10000000; i++)
    {
       ints.Add(rand.Next(0, 10000001));
    }
    string[] conditions = new string[] { "even", "div3", "div5" };
    var dynamicSort = new Sorted(ints);
    public class Sorted
    {
        public List<List<int>> returnVal { get; set; }
        public static List<int> Odd(List<int> ints)
        {
            return ints.Where(x => x % 2 != 0).ToList();
        }
        public static List<int> Even(List<int> ints)
        {
            return ints.Where(x => x % 2 == 0).ToList();
        }
        public static List<int> DivThree(List<int> ints)
        {
            return ints.Where(x => x % 3 == 0).ToList();
        }
        public static List<int> NotDivThree(List<int> ints)
        {
            return ints.Where(x => x % 3 != 0).ToList();
        }
        public static List<int> DivFive(List<int> ints)
        {
            return ints.Where(x => x % 5 == 0).ToList();
        }
        public static List<int> NotDivFive(List<int> ints)
        {
            return ints.Where(x => x % 5 != 0).ToList();
        }
        public Sorted(List<int> ints, string[] conditions)
        {
            returnVal = GetSorted(ints, conditions, 0);
        }
        public List<List<int>> GetSorted(List<int>ints, string[] conditions, int index)
        {
            var sortReturn = new List<List<int>>();
            switch (conditions[index].ToLower()) 
            {
                case "even":
                case "odd":
                    {
                        if (index == conditions.Length - 1)
                        {
                            sortReturn.Add(Odd(ints));
                            sortReturn.Add(Even(ints));
                        }
                        else
                        {
                            var i = ++index;
                            sortReturn.AddRange(GetSorted(Odd(ints), conditions, i));
                            sortReturn.AddRange(GetSorted(Even(ints), conditions, i));
                        }
                        break;
                    }
                case "div3":
                case "notdiv3":
                    {
                        if (index == conditions.Length - 1)
                        {
                            sortReturn.Add(DivThree(ints));
                            sortReturn.Add(NotDivThree(ints));
                        }
                        else
                        {
                            var i = ++index;
                            sortReturn.AddRange(GetSorted(DivThree(ints), conditions, i));
                            sortReturn.AddRange(GetSorted(NotDivThree(ints), conditions, i));
                        }
                        break;
                    }
                case "div5":
                case "notdiv5":
                    {
                        if (index == conditions.Length - 1)
                        {
                            sortReturn.Add(DivFive(ints));
                            sortReturn.Add(NotDivFive(ints));
                        }
                        else
                        {
                            var i = ++index;
                            sortReturn.AddRange(GetSorted(DivFive(ints), conditions, i));
                            sortReturn.AddRange(GetSorted(NotDivFive(ints), conditions, i));
                        }
                        break;
                    }
            }
            return sortReturn;
        }
    }
