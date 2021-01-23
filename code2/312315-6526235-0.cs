    protected void Page_Load(object sender, EventArgs e)
    {
        var xNames = new List<OFullName>();
        string TestString = "123ABCDEFGHIJK";
        for (int i = 1; i <= 10; i++)
        {
            xNames.Add(new OFullName(ShuffleString(TestString), ShuffleString(TestString)));
        }
        Repeater1.DataSource = xNames.OrderBy(x => x.LastName); // sorts by last name Ascending. Use OrderByDesc to sort descending.
        
        Repeater1.DataBind();//Bind data
    }
