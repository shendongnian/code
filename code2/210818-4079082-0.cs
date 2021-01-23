        private void button1_Click(object sender, EventArgs e)
        {
            ConfigurationManager.AppSettings.Set("TestData", "TestValue");
            
            if( ClassLibrary1.Class1.GetTestData() != null  )
                MessageBox.Show(ClassLibrary1.Class1.GetTestData());
            else
                MessageBox.Show("Not found");
        }
