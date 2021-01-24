    public DataSet getRecipes(string[] ingArray)
    {
        string sqlString = "SELECT recipes.Name, Instructions, recipes.Preperation_Time, Author FROM RecipeIngredients" +
                           " INNER JOIN recipes ON recipes.Recipe_ID = RecipeIngredients.Recipe_ID" +
                           " INNER JOIN Ingredients ON Ingredients.Ingredient_ID = RecipeIngredients.Ingredient_ID" +
                           " WHERE ingredients.Name = 'Eggs'";
        DataSet recipeDataSet = new DataSet();
        openConnection();
        dataAdapter = new SqlDataAdapter(sqlString, connectionToDB);
        //Fill dataset will create a table with the results
        // so you only need this one line:
        dataAdapter.Fill(recipeDataSet);
        closeConnection();
        return recipeDataSet;
    }
