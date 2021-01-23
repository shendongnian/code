    public static DataTable GetDataTable()
    {
        DataTable dt = new DataTable()
    
        // fill DataTable logic
        return dt;
    }
    
    public void main()
    {
      using(DataTable dt = GetDataTable())
      {
      // contine using dt
      }//here the table is disposed
    }
