     for(int i = 0; i < categories2.parentCategoryId.Count; i++)
     {
         var match = categories2.NewCategoryId.FirstOrDefault(stringToCheck => stringToCheck.Substring(0, 3) == categories2.parentCategoryId[i].Substring(0, 3)));
        if(match != null)
        {
                Console.Write(categories2.parentCategoryId[i] + " ");
                Console.Write(categories2.parentCategoryName[i] + "´          ");
                Console.Write(match  + " ");
                Console.Write(match  + "\n"); 
        }
     }
