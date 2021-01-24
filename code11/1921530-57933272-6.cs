    static void ForEachWay(){
        var enumerable = new List<string>();
        enumerable.Add("a");
        enumerable.Add("b");
        enumerable.Add("c");
        //you write
        foreach (string element in enumerable)
        {
            Console.WriteLine(element);
        }
    }
    static void EnumWayWithLoopVar(){
        var enumerable = new List<string>();
        enumerable.Add("a");
        enumerable.Add("b");
        enumerable.Add("c");
        string e;
        var enumerator = enumerable.GetEnumerator();
        try{ 
            while (enumerator.MoveNext())
            {
                e = enumerator.Current;
                Console.Write(e); 
            }
        }finally{
            enumerator.Dispose();
        }
    }
