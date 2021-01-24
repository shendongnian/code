     for(int i = 0; i < categories2.parentCategoryId.Count; i++)
     {
            if(categories2.parentCategoryId[i].Substring(0, 3) == categories2.NewCategoryId[i].Substring(0, 3)){
                Console.Write(categories2.parentCategoryId[i] + " ");
                Console.Write(categories2.parentCategoryName[i] + "´          ");
                Console.Write(categories2.NewCategoryId[i] + " ");
                Console.Write(categories2.NewCategoryName[i] + "\n"); 
        }
     }
