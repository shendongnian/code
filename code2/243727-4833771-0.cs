     foreach(MemberInfo member in type.GetMembers()) {
         Object[] myAttributes = member.GetCustomAttributes(true);
         if(myAttributes.Length > 0)
         {
             for(int j = 0; j < myAttributes.Length; j++){
             WoopAttribute woop =  myAttributes[j] as WoopAttribute;
                 if(woop!=null){
                     MemberInfo woopmember = member; //<--- gotcha
                 } 
             }
         }
     }
    
