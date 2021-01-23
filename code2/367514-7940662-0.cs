    namespace AutoCompleteTextBox
    {
      public partial class frmAuto : Form
      {
         public string strConnection = ConfigurationManager.AppSettings["ConnString"];
         AutoCompleteStringCollection namesCollection  =  new AutoCompleteStringCollection();
         public frmAuto()
         {
              InitializeComponent();
          }
    
          private void frmAuto_Load(object sender, EventArgs e)
          {
                  SqlDataReader dReader;
                   SqlConnection conn = new SqlConnection();
                   conn.ConnectionString = strConnection;
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;
                     cmd.CommandText ="Select distinct [Name] from [Names]" + " order by [Name] asc";
                      conn.Open();
                   dReader = cmd.ExecuteReader();
                  if (dReader.HasRows == true)
                  {
                         while (dReader.Read())
                         namesCollection.Add(dReader["Name"].ToString());
    
                   }
                   else
                   {
                            MessageBox.Show("Data not found");
                    }
                    dReader.Close();
    
                    txtName.AutoCompleteMode = AutoCompleteMode.Suggest;
                    txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtName.AutoCompleteCustomSource = namesCollection;
    
             }
             private void btnCancel_Click(object sender, EventArgs e)
             {
                      Application.Exit();
              }
              private void btnOk_Click(object sender, EventArgs e)
              {
                    MessageBox.Show(" this is autocomplete text box  example");
               }
    
           }
    }
