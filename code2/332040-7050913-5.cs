    var info = type.GetField("myField",BindingFlags.Private);
    if (info != null)
    {
         if (info.FieldType.IsGenericType)
         {
             foreach (var subType in info.FieldType.GetGenericArguments())
             {
                 if (subType.IsGenericParameter)
                 {
                     Console.WriteLine( "The type of the field is generic" );
                 }
             }
         }
    }
