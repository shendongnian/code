    private void populateBoxesWithIngredientResults(IEnumerable<ingredient> ingredientList, TextBox tb_name, TextBox tb_allergen)
    {
        string nameDelimiter = "";
        string allergenDelimiter = "";
    
        string ingredients = "";
        string allergens = "";
    
        var allergenTable = {"N/A", "Nut", "Gluten", "Dairy", "Egg"};
    
        foreach (ingredient ingredient in ingredientList)
        {
            //Is Convert.ToString() really needed here?
            // I feel like ingredient.IngredientName is ALREADY A STRING
            ingredients += delimiter + Convert.ToString(ingredient.IngredientName);
            nameDelimiter = ",";
    
            if (ingredient.AllergenID > 0 && ingredient.AllergenID < allergenTable.Length)
            {
                allergens += allergenDelimiter + allergenTable[ingredient.AllergenID];
                allergenDelimiter = ",";
            }
        }
        if (allergens == "") allergens = "N/A";
    
        tb_name.Text = ingredients;
        tb_allergen.Text = allergens;
    }
