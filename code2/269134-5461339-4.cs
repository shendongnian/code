    var myStruct = new MyStruct();
    myStruct.ReadXml(@".\MyXml.xml", XmlReadMode.ReadSchema);
    foreach (MyStruct.TestRow test in myStruct.Test)
    {
        Console.WriteLine("Test #" + test.Name);
        foreach (var param in test.GetParamsRows().SelectMany(ps => ps.GetParamRows()))
        {
            Console.WriteLine("- {0}: {1}", param.Name, param.Param_Text);
        }
    }
