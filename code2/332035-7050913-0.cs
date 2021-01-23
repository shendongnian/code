     var info = obj.GetType().GetField("myField",BindingFlags.Private);
     if (info != null)
     {
          if (info.FieldType.IsGenericType)
          {
               Console.WriteLine( "The type of the field is generic" );
          }
     }
