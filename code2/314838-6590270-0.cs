    public List<ListPeople> GetPeopleList(string Name, string opName, string Weight, string opWeight, string DOB, string opDOB)
    {
         var items = from a in ListPeople
                     select a;
         //--- repeat the section below for Weight and DOB
         if (!string.IsNullOrEmpty(Name))
         {
              switch(opName.ToLower())
              {
                   case "contains":
                   {
                       items = items.Where(a => SqlMethods.Like(a.Name, "%" + Name + "%"));
                       break;    
                   }
                   case "does not contain":
                   {
                       items = items.Where(a => !SqlMethods.Like(a.Name, "%" + Name + "%"));
                       break;    
                   }
                   case "is":
                   {
                       items = items.Where(a => a.Name == Name));
                       break;    
                   }
                   case "is not":
                   {
                       items = items.Where(a => a.Name != Name));
                       break;    
                   }
              }
         } 
         //--- end repeat
         return items.ToList();
    }
