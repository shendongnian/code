    public class SingletonClass
    {
        private static SingletonClass _Instance;
        public static SingletonClass Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new SingletonClass();
                return _Instance;
            }
        }   // End Property Instance
        private object _SelectedItem;
        public object SelectedItem
        {
            get { return _SelectedItem; }
            set { _SelectedItem = value; }
        } // End Selected Item
     }
    <DataGrid Name="Datagrid1" SelectedItem="{Binding Source={x:Static Const:SingletonClass.Instance},Path=SelectedItem,IsAsync=True}">
    <DataGrid Name="Datagrid2" SelectedItem="{Binding Source={x:Static Const:SingletonClass.Instance},Path=SelectedItem,IsAsync=True}">
