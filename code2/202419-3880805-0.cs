    static void Main(string[] argv)
    {
        var list = new[] { 0, 0, 0, 1, 2, 3, 4, 0, 0 };
        int groupIndex = 0;
        var result = list.Select(
            (e, i) =>
                {
                    if (i == 0)
                    {
                        return new {val = e, group = groupIndex};
                    }
                    else
                    {
                        groupIndex =
                            (e != 0 && list[i - 1] == 0) || (e == 0 && list[i - 1] != 0)
                                ?
                                    groupIndex + 1
                                : groupIndex;
                        return new {val = e, group = groupIndex};
                    }
                }
            ).GroupBy(e => e.group).Select(e => e.Select(o => o.val).ToList()).ToList();
        foreach (var item in result)
        {
            foreach (var val in item)
            {
                Console.Write(val + ";");
            }
            Console.WriteLine();
            Console.WriteLine("Count:" + item.Count);
            Console.WriteLine();
        }
        Console.ReadLine();
    }
