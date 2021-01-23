    private void Form1_Load(object sender, EventArgs e)
    {
        // Make a new list of result class objects, local to the Form1_Load method:
        List<Result> result = new List<Result>();
        // Call a method that populates a list... wait, what list?
        PopulateResult();
        dgresult.AutoGenerateColumns = false;
        dgresult.Items.Clear();
        // Set the datagrid data source to the list created earlier
        dgresult.ItemsSource = result;
        // ...
