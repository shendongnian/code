    static void Main()
    {
        Test testClass = new Test()
        {
            MyString = "some string",
            MyBool = true
        };
    
        Sequence wf = new Sequence()
        {
            Variables =
            {
                new Variable<Test>("varName", c => testClass),
            },
    
            Activities =
            {
                new WriteLine() { Text = new VisualBasicValue<string>("\"Test Class Properties: \" & varName.MyString & \"-\" & varName.MyBool") },
                new WriteLine() { Text = new VisualBasicValue<string>("\"Test Class ToString(): \" + varName") }
            }
        };
    
        var vbSettings = new VisualBasicSettings();
        vbSettings.ImportReferences.Add(new VisualBasicImportReference()
        {
            Assembly = typeof(Test).Assembly.GetName().Name,
            Import = typeof(Test).Namespace
        });
    
    
        VisualBasic.SetSettings(wf, vbSettings);
        WorkflowInvoker.Invoke(wf);
    
        Console.ReadKey();
    }
