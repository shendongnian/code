      if (String.IsNullOrEmpty(Subject_Code) && String.IsNullOrEmpty(Subject_Name)){
        return NotFound();
      } else{
           try{
             string sql = "INSERT INTO[dbo].[GEO_SUBJECT_CODES] ([Subject_Code],[Subject_Name_BY_CLASS]) VALUES " +
                            "('" + SubjectCodes.Subject_Code + "', '" + SubjectCodes.Subject_Name + "');";
                DBConnection dBConnection = new DBConnection();
                dBConnection.UpdateTable(sql);
            } catch (Exception ex){
                   //Your Code
            }
    }
