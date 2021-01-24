    public partial class MainWindow : Window
    {
      public static readonly DependencyProperty FilteredDataProperty = DependencyProperty.Register(
        "FilteredData", 
        typeof(DataTable),
        typeof(MainWindow));
      public DataTable FilteredData 
      {
        get { return (DataTable)GetValue(FilteredDataProperty); }
        set { SetValue(FilteredDataProperty, value); }
      }
      public static readonly DependencyProperty IsActiveFilterValueProperty = DependencyProperty.Register(
        "IsActiveFilterValue", 
        typeof(bool),
        typeof(MainWindow), 
        new PropertyMetadata(false, OnIsActiveFilterValueChanged));
      public bool IsActiveFilterValue
      {
        get { return (bool)GetValue(IsActiveFilterValueProperty); }
        set { SetValue(IsActiveFilterValueProperty, value); }
      }
      private DataTable UnfilteredData { get; set; }
      private String NameFilterValue { get; set; }
      private int CustomerNumberFilterValue { get; set; }
      public MainWindow()
      {
        InitializeComponent();
      }
      private void Button_Click(object sender, RoutedEventArgs e)
      {
        string connectionString = "Driver={Pervasive ODBC Client Interface};ServerName=875;dbq=@DBFS;Uid=Username;Pwd=Password;";
        string queryString = "select NRO,NAME,NAMEA,NAMEB,ADDRESS,POSTA,POSTN,POSTADR,COMPANYN,COUNTRY,ID,ACTIVE from COMPANY";
        // using-statement will cleanly close and dispose unmanaged resources i.e. IDisposable instances
        using (OdbcConnection dbConnection = new OdbcConnection(connectionString))
        {    
          dbConnection.Open();
          OdbcDataAdapter dadapter = new OdbcDataAdapter();
          dadapter.SelectCommand = new OdbcCommand(queryString, dbConnection);
        
          this.UnfilteredData = new DataTable("COMPANY");
          dadapter.Fill(this.UnfilteredData);
          this.FilteredData = this.UnfilteredData;
        }
      }
      private void ApplyFilterOnDataTable()
      {
        // Filter DataTable using LINQ
        this.FilteredData = this.Data
          .AsEnumerable()
          .Where(row => 
            string.IsNullOrWhiteSpace(this.NameFilterValue) 
              ? true // Filter criteria is ignored, when input is empty or null
              : row["NAME"].StartsWith(this.NameFilterValue)   
            && this.CustomerNumberFilterValue < 0 
              ? true // Filter criteria is ignored, when value is < 0
              : row["NRO"].ToString().StartsWith(this.CustomerNumberFilterValue.ToString())
            && this.IsActiveFilterValue 
              ? row["ACTIVE"].ToString().Equals("1")
              : true) // Filter criteris is ignored, when CheckBox is unchecked
          .CopyToDataTable();        
      }  
      private void OnNameSearchTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
      {       
        this.NameFilterValue = NameSearch.Text;
        ApplyFilterOnDataTable();  
      }
      private static void OnIsActiveFilterValueChanged(DependencyObject d, 
        DependencyPropertyChangedEventArgs e)
      {
        var _this = d as MainWindow;   
        _this.ApplyFilterOnDataTable();            
      }
      private void OnCustomerNumberSearch_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
      {  
        // Check if input is numeric 
        this.CustomerNumberFilterValue = Int32.TryParse(CustomerNumberSearch.Text, out int number) 
          ? number
          : -1; // Parsing failed -> not a numeric value. -1 will disable this filter criteria
        ApplyFilterOnDataTable();   
      }
    }
