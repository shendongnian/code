    for (int i = 0; i < arrayList.Count; i++)
    {
       string [] lineItems = (string []) arrayList[0];
       switch (i)
       {
       case 0: // id number (only digits are acceptable)
           if (lineItems.Any (lineItem => !Regex.IsMatch (lineItem, "^\d+$")))
               throw new ArgumentException ("id");
           break;
       case 1: // surnames (only letters a-z are acceptable)
           if (lineItems.Any (lineItem => !Regex.IsMatch (lineItem, "^[a-zA-Z]+$")))
               throw new ArgumentException ("id");
           break;
       case 1: // names (only letters a-z are acceptable)
           if (lineItems.Any (lineItem => !Regex.IsMatch (lineItem, "^[a-zA-Z]+$")))
               throw new ArgumentException ("id");
           break;
       }
    }
