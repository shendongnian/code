        public void COMPANIES_ACTIVATE_PACKAGE(long PI_COMPANY_ID, string PI_ACTIVE, long PI_USER_ID, out long PO_ERRCODE, out string PO_ERRMSG, out string PO_ORA_ERRMSG){
            StoredProcedure sp=new StoredProcedure("COMPANIES.ACTIVATE_PACKAGE",this.Provider);
            sp.Command.AddParameter("PI_COMPANY_ID",PI_COMPANY_ID,DbType.Decimal);
            sp.Command.AddParameter("PI_ACTIVE",PI_ACTIVE,DbType.AnsiString);
            sp.Command.AddParameter("PI_USER_ID",PI_USER_ID,DbType.Decimal);
            sp.Command.AddOutputParameter("PO_ERRCODE",DbType.AnsiString);
            sp.Command.AddOutputParameter("PO_ERRMSG",DbType.AnsiString);
            sp.Command.AddOutputParameter("PO_ORA_ERRMSG",DbType.AnsiString);
            sp.Execute();
            var prms = sp.Command.Parameters;
            PO_ERRCODE = ConvertValue<long>(prms.GetParameter("PO_ERRCODE").ParameterValue);
            PO_ERRMSG = ConvertValue<string>(prms.GetParameter("PO_ERRMSG").ParameterValue);
            PO_ORA_ERRMSG = ConvertValue<string>(prms.GetParameter("PO_ORA_ERRMSG").ParameterValue);
        }
