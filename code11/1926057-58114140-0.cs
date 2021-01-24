    public string selecteddetails (DOMAR SD)
        {
         DbCommand dbCommand = db.GetStoredProcCommand("Proc_SelectDetails");
         string out_name;
         string out_rollno;
         db.AddInParameter(dbCommand, "@id", DbType.Int32, SD.CaseID);
         db.AddOutParameter(dbCommand, "@NAME", DbType.String, 10);
         db.AddOutParameter(dbCommand, "@ROLLNO", DbType.String, 10);
         db.ExecuteNonQuery(dbCommand);
         out_name= (string)db.GetParameterValue(dbCommand, "@NAME");
     out_rollno= (string)db.GetParameterValue(dbCommand, "@ROLLNO");
         return out_name+out_rollno;
        }
