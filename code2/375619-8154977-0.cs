    <Window x:Class="BindToAdoDataDemo.Window1"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation">http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Window1" Height="300" Width="300">
      <DockPanel>
        <Button Width="120" Height="30" Content="Add" Name="btn" DockPanel.Dock="Top"/>
        <ListBox ItemsSource="{Binding}" DisplayMemberPath="ChildItem"/>
      </DockPanel>
    </Window>
    
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            DataTable dataTable = MakeChildTable();
            this.DataContext = dataTable.Rows;
            this.btn.Click += delegate
            {
                DataRow row = dataTable.NewRow();
                row["childID"] = 50;
                row["ChildItem"] = "ChildItem " + 50;
                dataTable.Rows.Add(row);    
            };
        }
    
        private DataTable MakeChildTable()
        {
            DataTable table = new DataTable("childTable");
            DataColumn column;
            DataRow row;
    
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "ChildID";
            column.Caption = "ID";
    
            table.Columns.Add(column);
    
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ChildItem";
            column.Caption = "ChildItem";
            table.Columns.Add(column);
    
            for (int i = 0; i <= 4; i++)
            {
                row = table.NewRow();
                row["childID"] = i;
                row["ChildItem"] = "Item " + i;
                table.Rows.Add(row);
            }
    
            return table;
        }
    }
