    DataAccess DAB = new DataAccess();
    ArrayList arrList = new ArrayList();
    string SQL = " insert into notepad (time, event) values (?,?) ";
    arrList.Add(new DataAccessBlock.DataAccess.Parameter("@time",  DbType.DateTime, 30, ParameterDirection.Input, "", strDate ));    
    arrList.Add(new DataAccessBlock.DataAccess.Parameter("@event", DbType.String, 50, ParameterDirection.Input, "", strEvent ));
    
    DAB.ExecuteScalar(SQL, CommandType.Text, arrList);
