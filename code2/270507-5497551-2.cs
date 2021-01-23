    var list = new List<int>();
    Task.Factory.StartNew(() => {
        for (int i = 0; i < 1000000; ++i) {
            list.Clear();
            // Add values from 1 to 9
            for (int j = 1; j < 10; ++j) {
                list.Add(j);
            }
        }
        Console.WriteLine("Thread Exit: list.Add()");
    });
    Task.Factory.StartNew(() => {
        for (int i = 0; i < 100; ++i) {
            var array = list.ToArray();
            if (array.Length > 0) {
                Console.WriteLine("ToArray(): {0}", string.Join(", ", array));
            }
        }
        Console.WriteLine("Thread Exit: list.ToArray()");
    });
