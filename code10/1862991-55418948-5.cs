    private void populateBoxesWithIngredientResults(List<ingredient> ingredientList, TextBox tb_name, TextBox tb_allergen)
    {    
        if (ingredientList.Length == 0)
        {
            tb_name.Text = "";
            tb_allergen.Text = "";
        }
    
        var allergenTable = {"N/A", "Nut", "Gluten", "Dairy", "Egg"};
        var ingredient = ingredientList[ingredientList.Count - 1];
    
        tb_name.Text = ingredient.IngredientName;  
        if (ingredient.AllergenID >= 0 && ingredient.AllergenID < allergenTable.Length)
        {
            tb_allergen.Text = allergenTable[ingredient.AllergenID];
        }
        else
        {
            tb_allergen.Text = "N/A";
        }
    }
