    public class MySqlDataSource : SqlDataSource
    {
        protected override SqlDataSourceView CreateDataSourceView(string viewName)
        {
            return new MySqlDataSourceView(this, viewName, this.Context);
        }
    }
    public class MySqlDataSourceView : SqlDataSourceView
    {
        private MySqlDataSource _owner;
        public MySqlDataSourceView(IPSqlDataSource owner, string name, System.Web.HttpContext context)
            : base(owner, name, context)
        {
            _owner = owner;
        }
        protected override string ParameterPrefix
        {
            get
            {
                if (!string.IsNullOrEmpty(this._owner.ProviderName) && !string.Equals(this._owner.ProviderName, "MyProvider", StringComparison.OrdinalIgnoreCase))
                {
                    return base.ParameterPrefix;
                }
                return "@";
            }
        }
    }
