    public ActionResult Edit(string id, string value)                   
    {                   
        string elementId = id; // First path, cyclomatic complexity is 1
        string fieldToEdit = elementId.Substring(0, 4); // Same path, CC still 1  
                                      
        int idToEdit = Convert.ToInt32(elementId.Remove(0, 4)); // Same path, CC still 1
        string newValue = value; // Same path, CC still 1
                   
        var food = dbEntities.FOODs.Single(i => i.FoodID == idToEdit); // Boolean expression inside your lambda. The result can go either way, so CC is 2.
                   
        switch (fieldToEdit) // Switch found, so CC is 3
        {                   
            case "name": food.FoodName = newValue; break; // First case - CC is 4
            case "amnt": food.FoodAmount = Convert.ToInt32(newValue); break; // Second case - CC is 5
            case "unit": food.FoodUnitID = Convert.ToInt32(newValue); break; // Third case - CC is 6
            case "sdat": food.StorageDate = Convert.ToDateTime(newValue); break; // Fourth case - CC is 7
            case "edat": food.ExpiryDate = Convert.ToDateTime(newValue); break; // Fifth case - CC is 8
            case "type": food.FoodTypeID = Convert.ToInt32(newValue); break; // Sixth case - CC is 9
                   
            default: throw new Exception("invalid fieldToEdit passed"); // Defaul found - CC is 10
                   
        }                   
        dbEntities.SaveChanges(); // This belongs to the first path, so CC is not incremented here.                   
        return Content(newValue);                   
    }        
