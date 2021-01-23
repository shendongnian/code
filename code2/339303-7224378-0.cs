    conn.Open();
    using (var tran = conn.BeginTransaction()) {
        comm.Transaction = tran; // Possibly redundant, depending on database.
        comm.CommandText = sql;
        result = comm.ExecuteNonQuery();
        tran.Commit();
    }
