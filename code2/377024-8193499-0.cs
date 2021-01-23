    class MyForm : Form
    {
       public MyForm()
       {
          InitializeComponent();
          DataAccess  dataAccess = new DataAccess();
          m_dataGrid.DataSource = DataAccess.SampleQuery("MyTable");
       }
    }
    
    class DataAccess 
    {
       public DataTable SampleQuery(string tablename)
       {
          DataTable dataTable;
          // 
          // Your Code
          // ..
          return dataTable;
       }
    }
