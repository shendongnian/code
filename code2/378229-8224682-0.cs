     public  class MyClass
        {
            public string Value { get; set; }
        }
      List<MyClass> k = new List<MyClass>();
            k.Add(new MyClass()
            {
                Value = "-5000"
            });
    
            k.Add(new MyClass()
            {
                Value = "- 5000"
            });
            rpt.DataSource = k;
            rpt.DataBind();
