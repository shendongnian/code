    public void Generate() 
    {
        var c = new CodeDomGenerator();
        c.AddNamespace("Samples")
         .AddClass("Form1")
         .AddMethod(MemberAttributes.Public | MemberAttributes.Static, ()=>"YourMethodName", Emit.stmt(() => MessageBox.Show("Method Body")));
    }
