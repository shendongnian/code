    private void Form1_Load(object sender, EventArgs e)
    {
        AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
        try
        {
            MyCollection.Add("Foo");
            MyCollection.Add("Bar");
            MyProductTextBox.AutoCompleteCustomSource = MyCollection;
            MyProductTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            MyProductTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
        }
        catch (Exception exc)
        {
            MessageBox.Show(exc.Message);
        }
    }
