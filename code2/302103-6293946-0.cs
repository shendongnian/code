    public static class Helper {
        public static DataTable ToDataTable<T>(this List<T> list) where T : class {
            Type type = typeof ( T );
            var ps = type.GetProperties ( );
            var cols = from p in ps
                       select new DataColumn ( p.Name , p.PropertyType );
            DataTable dt = new DataTable ( );
            dt.Columns.AddRange ( cols.ToArray ( ) );
            list.ForEach ( (l) => {
                List<object> objs = new List<object> ( );
                objs.AddRange ( ps.Select ( p => p.GetValue ( l , null ) ) );
                dt.Rows.Add ( objs.ToArray ( ) );
            } );
            return dt;
        }
    }
    public enum SendTypes {
        WeiBo ,
        QQ ,
        MSN ,
        EML
    }
    public class Receiver {
        public string Address {
            get;
            set;
        }
        public SendTypes SendType {
            get;
            set;
        }
        public string Msg {
            get;
            set;
        }
    }
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent ( );
        }
        private void SetDataGrid() {
            DataGridViewComboBoxColumn colSendType = new DataGridViewComboBoxColumn ( );
            colSendType.Items.AddRange ( SendTypes.EML, SendTypes.MSN, SendTypes.QQ, SendTypes.WeiBo );
            colSendType.Name = "SendType";
            
            colSendType.DataPropertyName = "SendType";
            this.dataGridView1.Columns.Add ( colSendType );
            DataGridViewTextBoxColumn colAddress = new DataGridViewTextBoxColumn ( );
            colAddress.Name = "Address";
            colAddress.DataPropertyName = "Address";
            this.dataGridView1.Columns.Add ( colAddress );
            this.dataGridView1.AutoGenerateColumns = false;
            //this.dataGridView1.AllowUserToAddRows = true;
        }
        private void LoadData() {
            var tmp = new Receiver {
                Address = "http://www.weibo.com/?uid=1000",
                SendType = SendTypes.WeiBo,
                Msg = "Test"
            };
            List<Receiver> datas = new List<Receiver>();
            datas.Add(new Receiver {
                Address = "http://www.weibo.com/?uid=1000",
                SendType = SendTypes.WeiBo,
                Msg = "Test"
            });
            datas.Add(new Receiver(){
                Address = "10001",
                SendType = SendTypes.QQ,
                Msg = "test"
            });
            datas.Add(new Receiver(){
                Address = "xling@abc.com",
                SendType = SendTypes.EML,
                Msg = "TEST TEST"
            });
            this.dataGridView1.DataSource = datas;//.ToDataTable();
        }
        private void Form1_Load(object sender , EventArgs e) {
            this.SetDataGrid ( );
            this.LoadData ( );
        }
        private void dataGridView1_DefaultValuesNeeded(object sender , DataGridViewRowEventArgs e) {
            dataGridView1.Rows[e.Row.Index].Cells["SendType"].Value = SendTypes.EML;
        }
    }
}
