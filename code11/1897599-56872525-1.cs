     string className = ...
     Type tp = TypeFromName(className);
     if (tp != null)
     {
         MemberInfo[] members = tp
           .GetMembers()
           .Where(p => p.MemberType == MemberTypes.Property);
         foreach (MemberInfo memberInfo in members)
         {
             Console.WriteLine("Name: {0}", memberInfo.Name); 
         }
     }
     else 
     {
         // className has not been found
     } 
