    private void populateBoxesWithIngredientResults(IEnumerable<ingredient> ingredientList, TextBox tb_name, TextBox tb_allergen)
    {       
        tb_name.Text = string.Join(",", ingredientList.Select(i => i.IngredientName));
        var allergenTable = {"N/A", "Nut", "Gluten", "Dairy", "Egg"};
        var allergens = ingredientList.
             Select(i => (i.AllergenID > 0 && i.AllergenID < allergenTable.Length)? allergenTable[i.AllergenID]):"").
             Where(i => i.Length > 0);
        var result = string.Join(",", allergens);
        if (string.IsNullOrEmpty(result)) result = "N/A";
        tb_allergen.Text = result;
    }
