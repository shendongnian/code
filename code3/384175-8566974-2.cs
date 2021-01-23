    public class UserControl1 : Button {
        string sqlstr;
        [Description("SQL STRING")]
        [DefaultValue(typeof (string), "")]
        public string SqlStr {
            get { return sqlstr; }
            set { sqlstr = value; }
        }
        protected override void OnClick(System.EventArgs e) {
            base.OnClick(e);
            MessageBox.Show(sqlstr);
        }
    }
