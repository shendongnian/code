    //this is just a template to simulate a datasource item
    public class TestItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
    
    public interface IAdministrarUsuariosView : IView
    {
    
        string NombreUsuarioABuscar { get; set; }
    
       // List<Perfil> ListaPerfiles { get; set; }
    
        event EventHandler BuscarUsuarioPorNombre;
        event EventHandler BuscarUsuarioPorPerfil;
        List<TestItem> SetComboBox { set; }
        List<TestItem> SetGridView { set; }
    
    }
