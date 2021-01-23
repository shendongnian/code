    OleDbConnection conn = new OleDB(); //obviously missing important stuff...
    conn.open();
    
    using(OleDbTransaction trans = conn.BeginTransaction()){
        try{
            OleDbCommand cmd1 = new OleDbCommand("insert into t1...", conn, trans);
            cmd1.ExecuteNonQuery();
    
            OleDbCommand cmd2 = new OleDbCommand("insert into t2...", conn, trans);
            cmd2.ExecuteNonQuery();
    
            trans.Commit();
        } catch {
            trans.Rollback();
        }
    }
    
    conn.close();
