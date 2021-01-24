    void PrintLists(LinkedList<string>[] lists, string[] captions)
    {
        foreach (var s in captions)
            Console.Write($"{s,-20}");
        Console.WriteLine();
        var iterators = new LinkedList<string>.Enumerator[lists.Length];
        var iteratorsValid = new bool[lists.Length];
        for (int i = 0; i < lists.Length; ++i)
        {
            iterators[i] = lists[i].GetEnumerator();
            iteratorsValid[i] = iterators[i].MoveNext();
        }
            
        while(iteratorsValid.Any(b => b))
        {
            for(int i = 0; i < lists.Length; ++i)
            {
                if (iteratorsValid[i])
                {
                    var item = iterators[i].Current;
                    Console.Write($"{item,-20}");
                    iteratorsValid[i] = iterators[i].MoveNext();
                }
                else
                    Console.Write(new String(' ', 20));
            }
            Console.WriteLine();
        }
    }
