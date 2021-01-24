      var inst = new Dictionary<int, double>();
    inst.Add(1, 82.65);
    inst.Add(2, 8.65);
    inst.Add(3, 8.89);
    inst.Add(4, 84.90);
    inst.Add(5, 7.95);
    
    var min = inst.Where(x => x.Value > 8).Min(x => x.Value);
    Console.WriteLine(min);
    var max = inst.Where(x => x.Value < 80).Max(x => x.Value);
    Console.WriteLine(max);
