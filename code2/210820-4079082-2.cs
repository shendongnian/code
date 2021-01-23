    private void button1_Click(object sender, EventArgs e)
    {
        ConfigurationManager.AppSettings.Set("TestData", "TestValue");
        
        string testData = ClassLibrary1.Class1.GetTestData();
        if (testData != null )
            MessageBox.Show(testData);
        else
            MessageBox.Show("Not found");
    }
