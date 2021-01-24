    class clsEstadoCuenta
    {
        //you will need a builder to create the lists
        public clsEstadoCuenta()
        {
            _FechaTrasaccion = new List<DateTime>();
            _Descripcion = new List<string>();
            _Referencia = new List<string>();
            _Payee = new List<string>();
            _Debito = new List<double>();
            _Credito = new List<double>();
            _Payee = new List<string>();
        }
        //method GetTransactionsNumber() 
        //heck how many items there are in the lists below
        public int GetTransactionsNumber()
        {
            return _FechaTrasaccion.Count;
        }
        //the methods below will be List since it 
        //will receive several values
        private List<DateTime> _FechaTrasaccion;
        public List<DateTime> FechaTransaccion
        {
            get { return _FechaTrasaccion; }
            set { _FechaTrasaccion = value; }
        }
        private List<string> _Descripcion;
        public List<string> Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        private List<string> _Referencia;
        public List<string> Referencia
        {
            get { return _Referencia; }
            set { _Referencia = value; }
        }
        private List<double> _Debito;
        public List<double> Debito
        {
            get { return _Debito; }
            set { _Debito = value; }
        }
        private List<double> _Credito;
        public List<double> Credito
        {
            get { return _Credito; }
            set { _Credito = value; }
        }
        private List<string> _Payee;
        public List<string> Payee
        {
            get { return _Payee; }
            set { _Payee = value; }
        }
        //private double _ValorLocal;
        //public double ValorLocal
        //{
        //    get
        //    {
        //        _ValorLocal = Credito - Debito;
        //        return _ValorLocal;
        //    }
        //    //set { _ValorLocal = value; }
        //}
        //private double _ValorDolares;
        //public double ValorDolares
        //{
        //    get
        //    {
        //        _ValorDolares = ValorLocal / TasaCambio;
        //        return _ValorDolares;
        //    }
        //    // set { _ValorDolares = value; }
        //}
        private string _NumeroCuenta;
        public string NumeroCuenta
        {
            get { return _NumeroCuenta; }
            set { _NumeroCuenta = value; }
        }
        private int _CodigoPais;
        public int CodigoPais
        {
            get { return _CodigoPais; }
            set { _CodigoPais = value; }
        }
        private string _Banco;
        public string Banco
        {
            get { return _Banco; }
            set { _Banco = value; }
        }
        private string _Moneda;
        public string Moneda
        {
            get { return _Moneda; }
            set { _Moneda = value; }
        }
        private double _TasaCambio;
        public double TasaCambio
        {
            get { return _TasaCambio; }
            set { _TasaCambio = value; }
        }
        private string _NombreEmpresa;
        public string NombreEmpresa
        {
            get { return _NombreEmpresa; }
            set { _NombreEmpresa = value; }
        }
        private string _CodigoBancario;
        public string CodigoBancario
        {
            get { return _CodigoBancario; }
            set { _CodigoBancario = value; }
        }
        private string _Categoria;
        public string Categoria
        {
            get { return _Categoria; }
            set { _Categoria = value; }
        }
        private string _Sector;
        public string Sector
        {
            get { return _Sector; }
            set { _Sector = value; }
        }
    }
