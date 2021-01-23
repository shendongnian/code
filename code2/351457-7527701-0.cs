    public delegate string EvalExpressionDelegate (Person);
    
    class CellInfo 
    {
         public string Title {get; set;}
         public string FormatString {get; set;}
         public EvalExpressionDelegate EvalExpression = null;
    }
    
    fields.Add("FirstName", new CellInfo 
                       {
                          Title = "First Name", 
                          FormatString = "Foo",
                          EvalExpression = p => p.FirstName
                       });
