// Assuming 'connection' is a valid connection to your database
string modid = "134"; // or int modid = 134;
string query = "SELECT Mod_Naam, Mod_Omschrijving 
                FROM Model 
                WHERE Mod_ID = " + modid;
SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
DataSet models = new DataSet();
adapter.Fill(models , "Models");
Next, you want the data to be attached to your GridView. You can put this in the Page_Load of your page, and in the if(!Page.IsPostBack) region if you only want to load the data on load of the page, but not on postback.
if (models.Tables.Count > 0)
{
    myGridView.DataSource = models;
    myGridView.DataBind();
}
