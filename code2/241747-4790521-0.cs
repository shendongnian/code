    partial class MyDataContext
    {
         [Function(Name="MySqlFunctionName", IsComposable=true)] 
         public ReturnType FunctionName(...args...) 
         { ... optional C# impl for AsEnumerable(),
               else throw NotImplementedException... }
    }
