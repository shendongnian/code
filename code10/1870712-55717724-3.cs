    var data = new List<DataSet>
    {
        new DataSet() { A = 1, B = "One", C = 1.1 },
        new DataSet() { A = 2, B = "Two", C = 2.2 },
        new DataSet() { A = 3, B = "Three", C = 3.3 }
    };
    var selectedData = SelectDynamicData(data, new List<string> { "A", "C" });
    foreach (List<dynamic> list in selectedData)
    {
        foreach (var item in list)
        {
            Console.Write(item);
        }
        Console.WriteLine();
    }
