    public class GridViewColumn : System.Windows.Controls.GridViewColumn
    {
        private BindingBase _cellBinding;
        public BindingBase CellBinding
        {
            get => _cellBinding;
            set => _cellBinding = value;
        }
        //...
    }
