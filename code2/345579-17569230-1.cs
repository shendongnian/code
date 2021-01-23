    public partial class Testfile : System.Web.UI.Page
    {
        public delegate void DelegateWriteToDB(string Inputstring);
        protected void Page_Load(object sender, EventArgs e)
        {
            getcontent(@"C:\Working\Teradata\New folder");
        }
          private void SendDataToDB(string data)
        {
            //InsertIntoData
              //Provider=SQLNCLI10.1;Integrated Security=SSPI;Persist Security Info=False;User ID="";Initial Catalog=kannan;Data Source=jaya;
            SqlConnection Conn = new SqlConnection("Data Source=aras;Initial Catalog=kannan;Integrated Security=true;");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into test_file values('"+data+"')";
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
          private void getcontent(string path)
          {
              string[] files;
              files = Directory.GetFiles(path, "*.txt");
              StringBuilder sbData = new StringBuilder();
              StringBuilder sbErrorData = new StringBuilder();
              Testfile df = new Testfile();
              DelegateWriteToDB objDelegate = new DelegateWriteToDB(df.SendDataToDB);
              //dt.Columns.Add("Data",Type.GetType("System.String"));
              
              foreach (string file in files)
              {
                  using (StreamReader sr = new StreamReader(file))
                  {
                      String line;
                      int linelength;
                      string space = string.Empty;
                      // Read and display lines from the file until the end of 
                      // the file is reached.
                      while ((line = sr.ReadLine()) != null)
                      {
                          linelength = line.Length;
                          switch (linelength)
                          {
                              case 5:
                                  space = "     ";
                                  break;
                             
                          }
                          if (linelength == 5)
                          {
                              IAsyncResult ObjAsynch = objDelegate.BeginInvoke(line + space, null, null);
                          }
                          else if (linelength == 10)
                          {
                              IAsyncResult ObjAsynch = objDelegate.BeginInvoke(line , null, null);
                          }
                      }
                  }
              }
          }
        }
