    class X
    {
         public string Name { get; set; }
         public double Value { get; set; }
         
         // name is an optional parameter (this means it can be used only in C# 4)
         public X(double value, string name = "")
         {
             this.Name = name;
             this.Value = value;
         }
         // whatever
    }
