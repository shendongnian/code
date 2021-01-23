    public interface IOracleCommand : IDbCommand
    {
        void OracleMethod();
        string OracleProperty { get; set; }
    }
    public class OracleCommandWrapper : IOracleCommand
    {
        private OracleCommand _inner;
        public OracleCommandWrapper(OracleCommand inner)
        {
            _inner = inner;
        }
        public void Dispose()
        {
            _inner.Dispose();
        }
        public IDbDataParameter CreateParameter()
        {
            return _inner.CreateParameter();
        }
        // do this for all the members, including the Oracle-specific members
        public void OracleMethod()
        {
            _inner.OracleMethod();
        }
        public string OracleProperty
        {
            get { return _inner.OracleProperty; }
            set { _inner.OracleProperty = value; }
        }
    }
