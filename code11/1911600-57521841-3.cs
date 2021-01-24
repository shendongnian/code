        var a = new ArrayStruct<string>();
        a.Add("hello");
        var b = ArrayStruct<string>.CopyFrom(a);
        a.SetAt(0, "new value for a");
        a.Add("resizing array");
        Console.WriteLine(b.Count); // b returns 1
        Console.WriteLine(a.Count); // a returns 2
