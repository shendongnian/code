        public static DateTime FindServerDateTime()
        {
            return Helper.GetSession()
                .CreateSQLQuery("select getdate()")
                .UniqueResult<DateTime>();
        }
