     string connectionString = "connectionstring";
            var sqlConnection = new SqlConnection(connectionString);
            var command = sqlConnection.CreateCommand();
            //****************Setup Mock************************//
            Castle.DynamicProxy.Generators.AttributesToAvoidReplicating.Add(typeof(System.Data.SqlClient.SqlClientPermissionAttribute));
            var mockDataReader1 = new Mock<IDataReader>();
            command.Parameters.Add(new SqlParameter("@po_tint_Result", 1));
            //setup read return value
            Queue<bool> responseQueue = new Queue<bool>();
            responseQueue.Enqueue(true);
            responseQueue.Enqueue(false);
            mockDataReader1.Setup(a => a.Read()).Returns(() => responseQueue.Dequeue());
            var mockDb = new Mock<SqlDatabase>(connectionString);
            mockDb.Setup(a => a.GetStoredProcCommand("SPNAME")).Returns(command);
            mockDb.Setup(a => a.ExecuteNonQuery(command));
            obj1.DbConn = mockDb.Object;
            //*************************************************//
