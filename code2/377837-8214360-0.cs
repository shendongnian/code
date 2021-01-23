    dynamic obj = new System.Dynamic.ExpandoObject();
    obj.Value = 10;
    var action = new Action<string>((l) => Console.WriteLine(l));
    obj.WriteNow = action;
    obj.WriteNow(obj.Value.ToString());
