     var info = type.GetField("myField",BindingFlags.Private);
     if (info != null)
     {
          if (info.FieldType.IsGenericParameter)
          {
               Console.WriteLine( "The type of the field is generic" );
          }
     }
