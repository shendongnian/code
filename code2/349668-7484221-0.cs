    void tester_Done(double runTime)
    {
        DataTable myTable = new DataTable();
    
        //Here i fill the myTable with rows and columns
    
        TestGrid.DataSource = (myTable).DefaultView;
        TestGrid.DataBind();
        UpdateTestingGrid.Update(); // UpdateMode must be Conditional
     }
