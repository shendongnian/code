    cmd.CommandText = "SELECT * FROM Question WHERE SurveyID= '" + sID + "'";    
    dr = cmd.ExecuteReader();  
    List<string> arrSQL = new List<string>();
    while (dr.Read())
    {
        int ids = Int32.Parse(dr["QuestionID"].ToString());
        arrSQL.Add("INSERT INTO Answers (QuestionId,Answer) Select c.QnId, c.Answer From TempAns c Where c.Id = " + ids + " ");
    }
    dr.Close();
    
    arrSQL.ForEach(strSQL =>
    {
        cmd.CommandText = strSQL;
        cmd.ExecuteNonQuery();
    });
