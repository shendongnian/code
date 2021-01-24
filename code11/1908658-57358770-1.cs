    public class Rootobject
    {
        public Body[] body { get; set; }
    }
    public class Body
    {
        public int id { get; set; }
        public string processInstanceId { get; set; }
        public Tipotramite tipoTramite { get; set; }
        public Canal canal { get; set; }
        public Definiciontramite definicionTramite { get; set; }
        public Institucion institucion { get; set; }
        public int idDepartamento { get; set; }
        public int idArea { get; set; }
        public Estado estado { get; set; }
        public string cve { get; set; }
        public string numeroSolicitud { get; set; }
        public int tarifa { get; set; }
        public Rut rut { get; set; }
        public Rutempresa rutEmpresa { get; set; }
        public string nombre { get; set; }
        public bool flagPagado { get; set; }
        public long fechaCreacion { get; set; }
        public long fechaModificacion { get; set; }
        public Datostramite[] datosTramite { get; set; }
        public string deploymenId { get; set; }
        public string processId { get; set; }
        public string solicitante { get; set; }
        public string contribuyente { get; set; }
        public string keyConfiguracion { get; set; }
    }
    public class Tipotramite
    {
        public int id { get; set; }
        public string descripcion { get; set; }
    }
    public class Canal
    {
        public int id { get; set; }
        public string nombre { get; set; }
    }
    public class Definiciontramite
    {
        public int id { get; set; }
        public object tipoTramite { get; set; }
        public int idEstado { get; set; }
        public int version { get; set; }
        public int idDepartamento { get; set; }
        public int idArea { get; set; }
        public string nombre { get; set; }
        public object codigo { get; set; }
        public object descripcion { get; set; }
        public object deploymentId { get; set; }
        public object configuracion { get; set; }
        public object processId { get; set; }
    }
    public class Institucion
    {
        public int id { get; set; }
        public object idInstitucionBase { get; set; }
        public object tipoInstitucion { get; set; }
        public string nombre { get; set; }
        public string codigo { get; set; }
        public object direccion { get; set; }
        public object logoWeb { get; set; }
        public object logoPdf { get; set; }
        public object telefonoFijo { get; set; }
        public object email { get; set; }
        public object propietario { get; set; }
    }
    public class Estado
    {
        public int id { get; set; }
        public Definiciontramite1 definicionTramite { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
    }
    public class Definiciontramite1
    {
        public int id { get; set; }
        public object tipoTramite { get; set; }
        public int idEstado { get; set; }
        public int version { get; set; }
        public int idDepartamento { get; set; }
        public int idArea { get; set; }
        public object nombre { get; set; }
        public object codigo { get; set; }
        public object descripcion { get; set; }
        public object deploymentId { get; set; }
        public object configuracion { get; set; }
        public object processId { get; set; }
    }
    public class Rut
    {
        public int numero { get; set; }
        public string dv { get; set; }
    }
    public class Rutempresa
    {
        public int numero { get; set; }
        public string dv { get; set; }
    }
    public class Datostramite
    {
        public int id { get; set; }
        public string key { get; set; }
        public string tipo { get; set; }
        public string data { get; set; }
    }
