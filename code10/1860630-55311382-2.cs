     private void resultsWindow_Load(object sender, EventArgs e)
        {
            //gets connection string
            string connectionString = Properties.Settings.Default.ConnectionString;
        
            DataSet recipeDataSet = new DataSet();
            conn = new DatabaseConnections(connectionString);
        
            //Gets dataset
            Datatable dt1 = conn.getRecipes(ingredientArray);
        
            //Displays data in grid view
        recipesDataGrid.DataSource = dt1.DefaultView;
 
           
        }
       public DataTable getRecipes(string[] ingArray)
    {
        string sqlString = "SELECT recipes.Name, Instructions, recipes.Preperation_Time, Author FROM RecipeIngredients" +
                           " INNER JOIN recipes ON recipes.Recipe_ID = RecipeIngredients.Recipe_ID" +
                           " INNER JOIN Ingredients ON Ingredients.Ingredient_ID = RecipeIngredients.Ingredient_ID" +
                           " WHERE ingredients.Name = 'Eggs'";
        DataTable recipeDataTable = new DataTable();
        openConnection();
        dataAdapter = new SqlDataAdapter(sqlString, connectionToDB);
        //Fills dataset
        dataAdapter.Fill(recipeDataTable);
        closeConnection();
        return recipeDataTable;
