    public class MyDataTable : System.Data.DataTable {
        private Brush _myBackground = Brushes.AliceBlue;
        public Brush MyBackground {
            get {
                return _myBackground;
            }
            set {
                _myBackground = value;
                NotifyPropertyChanged(nameof(MyBackground));
            }
        }
    }
    
    public MyDataTable Table { get; } = new MyDataTable();
    
    <Style TargetType="{x:Type DataGridRow}">
        <Setter Property="Background" Value="{Binding MyBackground }" />
    </Style>
