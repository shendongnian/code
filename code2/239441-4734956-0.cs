    protected void Page_Load(object sender, EventArgs e)
    {
        List<TestOne> testOneItems = new List<TestOne>();
        TestOne testOne = new TestOne { TestProperty = new TestOne.TestInner { TestInnerProperty = "test Inner Property" }};
        testOneItems.Add(testOne);
    
        GridView1.DataSource = testOneItems;
        GridView1.DataBind();
    }
