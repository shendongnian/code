    private void On_Inserting(Object sender, SqlDataSourceCommandEventArgs e)
    {
        e.Command.Parameters.Add(new SqlParameter("ItemDateAddedTextBox", DateTime.Now.ToString("MMMM dd, yyyy")));
        ...
    }
