    public class YourView:IAdministrarUsuariosView
    {
        public string NombreUsuarioABuscar
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    
        public event EventHandler BuscarUsuarioPorNombre;
        public event EventHandler BuscarUsuarioPorPerfil;
    
        public List<TestItem> SetComboBox
        {
            set
            {
                ComboBox.DataSource = value;
                //your need to specify value and text property
                ComboBox.DataBind();
            }
        }
    
        public List<TestItem> SetGridView
        {
            set
            {
                GridView.DataSource = value;
                //your need to specify value and text property
                GridView.DataBind();
    
            }
        }
    }
