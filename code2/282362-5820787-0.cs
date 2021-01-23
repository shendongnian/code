    private static void Main(string[] args)
{
    var testClass = new Test { MyString = "some string", MyBool = true };
    var wf = new Sequence
        {
            Variables = {
                            // Changed to use ActivityFunc so testClass is not interpreted as a literal
                            new Variable<Test>("varName", ctx => testClass), 
                        }, 
            Activities =
                {
                    new WriteLine
                        {
                            Text =
                                new VisualBasicValue<string>(
                                "\"Test Class Properties: \" & varName.MyString & \"-\" & varName.MyBool")
                        }, 
                        // Changed to call ToString explicitly
                        new WriteLine { Text = new VisualBasicValue<string>("\"Test Class ToString(): \" & varName.ToString()") }
                }
        };
    var settings = new VisualBasicSettings();
    settings.ImportReferences.Add(
        new VisualBasicImportReference
            {
                Assembly = typeof(Test).Assembly.GetName().Name, Import = typeof(Test).Namespace 
            });
                
    // construct workflow
    VisualBasic.SetSettings(wf, settings);
    WorkflowInvoker.Invoke(wf);
    Console.ReadKey();
