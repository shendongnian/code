    void PrintLists(LinkedList<string>[] lists, string[] captions)
    {
        //Find the necessary column widths
        var columnWidths = new int[lists.Length];
        for(int i = 0; i < lists.Length; ++i)
        {
            columnWidths[i] = captions[i].Length;
            foreach (var s in lists[i])
                columnWidths[i] = Math.Max(columnWidths[i], s.Length);
            columnWidths[i] += 2; //spacing
        }
        //Print the headings
        for(int i = 0; i < lists.Length; ++i)
            Console.Write(captions[i].PadRight(columnWidths[i]));
        Console.WriteLine();
        //Initialize iterators
        var iterators = new LinkedList<string>.Enumerator[lists.Length];
        var iteratorsValid = new bool[lists.Length];
        for (int i = 0; i < lists.Length; ++i)
        {
            iterators[i] = lists[i].GetEnumerator();
            iteratorsValid[i] = iterators[i].MoveNext();
        }
        //Print the rest of the table
        while (iteratorsValid.Any(b => b))
        {
            for (int i = 0; i < lists.Length; ++i)
            {
                if (iteratorsValid[i])
                {
                    var item = iterators[i].Current;
                    Console.Write(item.PadRight(columnWidths[i]));
                    iteratorsValid[i] = iterators[i].MoveNext();
                }
                else
                    Console.Write(new String(' ', columnWidths[i]));
            }
            Console.WriteLine();
        }
    }
