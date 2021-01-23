      enum DBType { Int, Double, Float, Bool, String  }
    
      class DBProperties
      {
        private DBType dbType;
        public DBType DBType { get { return dbType; } set { dbType = value; } }
      }
    
      public partial class Form1 : Form
      {
        public Form1()
        {
          InitializeComponent();
        }
    
        private void cbDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
          DBType val = (DBType)cbDataType.SelectedIndex;
          cbDataType.SelectedIndex = (int)val;
          var dbProperties = new DBProperties();
          dbProperties.DBType = val;
        }
      }
