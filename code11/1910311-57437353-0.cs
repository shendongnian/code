    var lines = txtStatus.Lines;
    test.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)
        .ToList().ForEach((line)=> 
        {
            line = line.Substring(1);
        });
