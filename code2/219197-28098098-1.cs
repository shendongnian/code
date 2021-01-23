    Dim cn As SqlConnection, cm As SqlCommand, dr As SqlDataReader
    Dim myCount As Int32
    
    cn = New SqlConnection("MyConnectionString")
    cn.Open() //I open my connection beforehand, but a lot of people open it right before executing the queries. Not sure if it matters.
    
    cm = New SqlCommand("spMyStoredProcedure", cn)
    cm.CommandType = CommandType.StoredProcedure
    cm.Parameters.Add("@TotalRows", SqlDbType.Int).Direction = ParameterDirection.Output
    cm.ExecuteNonQuery()
    
    myCount = CType(cm.Parameters("@TotalRows").Value, Integer)
    If myCount > 0 Then
         //Do something.
    End If
    
    dr = cm.ExecuteReader()
    If dr.HasRows Then
         //Return the actual query results using the stored procedure's 1st SELECT statement
    End If
    dr.Close()
    cn.Close()
    dr = Nothing
    cm = Nothing
    cn = Nothing
