    class ParamBuilder
    {
        private DbProviderFactory m_factory;
        private DbCommandBuilder m_builder;
        private string m_parameterMarkerFormat;
        public ParamBuilder(DbProviderFactory factory) : this(factory, null)
        {
        }
        public ParamBuilder(DbProviderFactory factory, DbConnection source)
        {
            m_factory = factory;
            m_builder = m_factory.CreateCommandBuilder();
            if (source != null)
            {
                using (DataTable tbl =
                    source.GetSchema(DbMetaDataCollectionNames.DataSourceInformation))
                {
                    m_parameterMarkerFormat =  
                        tbl.Rows[0][DbMetaDataColumnNames.ParameterMarkerFormat] as string;
                }
            }
            if (String.IsNullOrEmpty(m_parameterMarkerFormat))
                m_parameterMarkerFormat = "{0}";
        }
        public DbParameter CreateParameter(string parameterName, 
            out string parameterMarker)
        {
            DbParameter param = m_factory.CreateParameter();
            param.ParameterName =  
                (string)typeof(DbCommandBuilder).InvokeMember("GetParameterName",
                    System.Reflection.BindingFlags.Instance |
                    System.Reflection.BindingFlags.InvokeMethod |
                    System.Reflection.BindingFlags.NonPublic, null, m_builder, 
                    new object[] { parameterName });
            parameterMarker = 
                String.Format(System.Globalization.CultureInfo.InvariantCulture, 
                m_parameterMarkerFormat, param.ParameterName);
            return param;
        }
  
    }
