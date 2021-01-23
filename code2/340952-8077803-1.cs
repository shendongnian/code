    public partial class Form1 : Form
    {
        UltraCombo uc;
        public Form1()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt.Columns.Add("Int", typeof(int));
            dt.Rows.Add(1);
            dt.Rows.Add(1);
            dt.Rows.Add(1);
            DataTable dtt = new DataTable();
            dtt.Columns.Add("Int", typeof(int));
            dtt.Rows.Add(2);
            dtt.Rows.Add(2);
            dtt.Rows.Add(2);
            uc = new UltraCombo();
            uc.BindingContext = this.BindingContext;
            uc.DataSource = dtt;
           
            ultraGrid1.DataSource = dt.DefaultView;
        }
        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.Bands[0].Columns[0].EditorComponent = uc;
        }
    }
