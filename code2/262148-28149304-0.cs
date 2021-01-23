    using (var sqlConnection = new SqlConnection(TEST_CONNECTION_STRING))
    {
        sqlConnection.Open();
        int changesReceived = 0;
        using (SqlDependencyEx sqlDependency 
            = sqlConnection.GetSqlDependencyEx(TEST_TABLE_NAME))
        {
            // Changes receive independently in parallel thread
            sqlDependency.TableChanged += (o, e) => changesReceived++;
            sqlDependency.Start();
            // Make simple changes in the table
            MakeTableInsertDeleteChanges(changesCount);
            // Wait a little bit to receive all changes.
            Thread.Sleep(1000);
        }
        Assert.AreEqual(changesCount, changesReceived);
    }
