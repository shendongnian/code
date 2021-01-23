    OleDbConnection con = new OleDbConnection(string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='{0}'", DBPath));
    OleDbCommand cmd = con.CreateCommand();
    con.Open();
    cmd.CommandText = string.Format("INSERT INTO Tasks (TaskName, Task, CreatedBy, CreatedByEmail, CreatedDate, EmailTo, EmailCC) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", subject, ConvertHtmlToRtf(htmlBody), fromName, fromEmail, sentOn, emailTo, emailCC);
    cmd.Connection = con;
    cmd.ExecuteScalar();
    using (OleDbCommand command = new OleDbCommand("SELECT @@IDENTITY;", con))
    {
        ReturnIDCast =(int)command.ExecuteScalar();
    }
