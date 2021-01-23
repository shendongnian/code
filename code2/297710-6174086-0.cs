     // Create the TransactionScope
    using (TransactionScope oTranScope = new TransactionScope())
    {
       Int32 TopicID;
        // Open a connection to SQL Server 2005
        using (SqlConnection oCn1 = new SqlConnection(this.sCn1))
        {
            SqlCommand oCmd1 = new SqlCommand("INSERT INTO Users (UserID,TopicID,Date,ThreadTitle,ThreadParagraph) " +
    "VALUES ('CONVERT(uniqueidentifier, '" + giveMeGuidID() +
    "),TopicID,dateTime,questionTitle,subTopic); SELECT SCOPE_IDENTITY()";, oCn1);
            oCmd1.Parameters.Add ... Better to use parameter to save SQL Injection Attack
            oCn1.Open();
            // At this point, the connection is in the transaction scope, 
            // which is a lightweight transaction.
            TopicID = Convert.ToInt32 oCmd1.ExecuteNonQuery());
            oCn1.Close();
        }
        // Open a connection to SQL Server 2000
        using (SqlConnection oCn2 = new SqlConnection(this.sCn2))
        {
            SqlCommand oCmd2 = new SqlCommand("SQLQuery", oCn2);
            //use return TopicID from last inserted query
            oCn2.Open();
            // The connection is enlisted in the transaction scope, 
            // which is now promoted to a distributed transaction
            // controlled by MSDTC
            oCmd2.ExecuteNonQuery();
            oCn2.Close();
        }
        // Tell the transaction scope to commit when ready 
        oTranScope.Consistent = true;
        // The following bracket completes and disposes the transaction
    }
