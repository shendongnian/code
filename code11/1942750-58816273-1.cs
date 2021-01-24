    public static void Main()
    {
        var sublist1 = new List<string>{ "a", "b" };
        var sublist2 = new List<string>{ "a", "b" };
        var sublist3 = new List<string>{ "a", "c" };
        var listOfLists = new List<List<string>> {sublist1, sublist2, sublist3};
        var groups = listOfLists.GroupBy(item => item, new StringListEqualityComparer());
        foreach (var group in groups)
        {
            Console.WriteLine($"Group: {string.Join(", ", group.Key)}, Count: {group.Count()}");
        }
    }
