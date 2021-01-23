private void PopulateDatabases(string serverName)
{
        //populate Databases
        //.. your code here ...
        //clear the list
        DatabasenamesList.Items.Clear();
        foreach (var database in Databases)
        {
            DatabasenamesList_combobox.Items.Add(database);
        }
}
