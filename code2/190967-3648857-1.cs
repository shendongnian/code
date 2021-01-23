    using System;
    using System.Collections;
    using NHibernate.SqlCommand;
    using NHibernate.Type;
    
    namespace NHibernate
    {
        [Serializable]
        public class MyInterceptor : IInterceptor
        {
            ...
    
            public SqlString OnPrepareStatement(SqlString sql)
            {
                ///Do what is required here to alter the SQL string
                return sql;
            }
        }
    }
