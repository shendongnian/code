    // untested
    using (var file = System.IO.File.CreateText("data.txt"))
    {
       foreach(var item in data)
          file.WriteLine("{0}={1}", item.Key, item.Value);
    }
