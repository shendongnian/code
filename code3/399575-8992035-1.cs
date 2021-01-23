    public static void Main(string[] args)
    {
        DataSet dataSet = getDataSet();
        string htmlString= getHtml(dataSet);
        SendAutomatedEmail(htmlString, "email@domain.com");
    }
    public static DataSet getDataSet(string CommandText)
    {
        string cnString = ConfigurationManager.ConnectionStrings["Connection2"].ConnectionString;
        SqlConnection sqlConnection = new SqlConnection(cnString);
        string CommandText = "select * from dbo.fs010100 (nolock)";
        SqlCommand sqlCommand =  new SqlCommand( CommandText, sqlConnection);
        SqlDataAdapter sqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
        sqlDataAdapter.SelectCommand = sqlCommand;
        DataSet dataSet = new DataSet();
        try
        {
            sqlDataAdapter.Fill(dataSet, "header");
            sqlConnection.Close();
        }
        catch (Exception _Exception)
        {
            sqlConnection.Close();
            return null;
        }
        return dataSet;
        
    }
    public static string getHtml(DataSet dataSet)
    {
        try
        {
             string messageBody = "<font>The following are the records: </font><br><br>";
    
             if (dataSet.Tables[0].Rows.Count == 0)
                 return messageBody;
             string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
             string htmlTableEnd = "</table>";
             string htmlHeaderRowStart = "<tr style =\"background-color:#6FA1D2; color:#ffffff;\">";
             string htmlHeaderRowEnd = "</tr>";
             string htmlTrStart = "<tr style =\"color:#555555;\">";
             string htmlTrEnd = "</tr>";
             string htmlTdStart = "<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\">";
             string htmlTdEnd = "</td>";
                    
             messageBody+= htmlTableStart;
             messageBody += htmlHeaderRowStart;
             messageBody += htmlTdStart + "Column1 " + htmlTdEnd;
             messageBody += htmlHeaderRowEnd;
    
             foreach (DataRow Row in notShippedDataSet.Tables[0].Rows)
             {
                 messageBody = messageBody + htmlTrStart;
                 messageBody = messageBody + htmlTdStart + Row["fieldName"] + htmlTdEnd;
                 messageBody = messageBody + htmlTrEnd;
             }
             messageBody = messageBody + htmlTableEnd;
                    
    
             return messageBody;
         }
         catch (Exception ex)
         {
              return null;
         }
     }
    public static void SendAutomatedEmail(string htmlString, string recipient = "user@domain.com")
    {
     try
     {
         string mailServer = "server.com";
         MailMessage message = new MailMessage("it@domain.com", recipient);
         message .IsBodyHtml = true;
         message .Body = htmlString;
         message .Subject = "Test Email";
         SmtpClient client = new SmtpClient(mailServer);
         var AuthenticationDetails = new NetworkCredential("user@domain.com", "password");
         client.Credentials = AuthenticationDetails;
         client.Send(message);
     }
     catch (Exception e)
     {
   
     }
    
    }
