      public class MsSql2008ExtendedDialect : MsSql2008Dialect
        {
            public MsSql2008ExtendedDialect()
            {
                RegisterFunction("DATEPART_HOUR", new SQLFunctionTemplate(NHibernateUtil.DateTime, "datepart(hh, ?1)"));
            }
        } 
