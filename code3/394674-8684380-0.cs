        public partial class Form1 : Form
        {
            private readonly DataGridView _gridView;
            private readonly DataTable _dataTable;
    
            public Form1()
            {
                InitializeComponent();
    
                _dataTable = new DataTable();
                DataColumn computerColumn = new DataColumn("Name");
                _dataTable.Columns.Add(computerColumn);
                _dataTable.Columns.Add(new DataColumn("IP"));
                _dataTable.Columns.Add(new DataColumn("MAC"));
                _dataTable.Columns.Add(new DataColumn("Descubierto"));
                _dataTable.PrimaryKey = new [] { computerColumn };
    
                _gridView = new DataGridView
                                {
                                    Dock = DockStyle.Fill,
                                    DataSource = _dataTable
                                };
                Controls.Add(_gridView);
    
                System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000;
                timer.Tick += TimerTick;     
                timer.Start();
            }
    
            void TimerTick(object sender, EventArgs e)
            {
                DirectoryEntry domainEntry = new DirectoryEntry("WinNT://mydomain"); 
                domainEntry.Children.SchemaFilter.Add("Computer"); 
    
                _dataTable.BeginLoadData();
     
                foreach (DirectoryEntry machine in domainEntry.Children) 
                { 
                    DataRow row = _dataTable.Rows.Find(machine.Name);
    
                    if(row == null)
                    {
                        row = _dataTable.NewRow();
                        row[0] = machine.Name;
                        _dataTable.Rows.Add(row);
                    }
    
                    row[3] = DateTime.Now.ToString();
                }
    
                _dataTable.EndLoadData();
            } 
        }
