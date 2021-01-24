    public static async Task<DataTable> GetData(int id, DateTime birthdate)
        {
            ProcedureParameters parameters = new ProcedureParameters();
            parameters.Add("@id", SqlDbType.TinyInt, id);
            parameters.Add("@birthdate", SqlDbType.SmallDateTime, birthdate);
            return await DataBaseHelper.GetDataAsync("<conection string>", "<procedure name>", parameters);
        }
