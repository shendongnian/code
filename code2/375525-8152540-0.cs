        List<dynamic> list = new List<dynamic>();
            Action<int, int> myFunc = (int x, int y) => Console.WriteLine("{0}, {1}", x, y);
            Action<int, int> myFunc2 = (int x, int y) => Console.WriteLine("{0}, {1}", x, y);
            list.Add(myFunc);
            list.Add(myFunc2);
            (list[0])(5, 6);
