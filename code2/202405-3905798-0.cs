    private void Form1_Load(object sender, System.EventArgs e)
    {
        for(int i = 0; i < 100; i++)
        {
           EmployeeList.Items.Add(new Employee());
        }
        
        // Bind EmployeeList to your ListView
        ListView.ItemSource = EmployeeList;
    }
