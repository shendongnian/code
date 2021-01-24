    public IEnumerable<Insurance> GetInsuranceByANI(string ani)
    {
        using (ITransaction transaction = Session.Value.BeginTransaction())
        {
            transaction.Rollback();
            IDbCommand command = new SqlCommand();
            command.Connection = Session.Value.Connection;
            transaction.Enlist(command);
            string storedProcName = "spGetInsurance";
            command.CommandText = storedProcName;
            command.Parameters.Add(new SqlParameter("@ANI", SqlDbType.Char, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Default, ani));
            var rdr = command.ExecuteReader();
            return MapInsurance(rdr);
        }
    }
