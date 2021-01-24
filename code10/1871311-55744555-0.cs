        public partial class Unit : UserControl
        {
            private ProductUnit _pu= new ProductUnit();
            public ProductUnit PU
            {
                get {return _pu;} // read only
            }
            public Unit()
            {
                InitializeComponent();
            }
        
            private void BtnAdd_Click(object sender, RoutedEventArgs e)
            {
               _pu.UnitNicname = TxtUnitNicName.Text;
               _pu.UnitFaName = TxtUnitName.Text;
               StructureMapDefenation.Container.GetInstance<IUnitService>().Add(_pu);
            }
        }
