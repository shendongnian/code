    class X
    {
         public string Name { get; set; }
         public double Value { get; set; }
         
         // here I'm using an optional parameter, a C# 4 feature
         public X(string name = "", double value)
         {
             this.Name = name;
             this.Value = value;
         }
         // whatever
    }
