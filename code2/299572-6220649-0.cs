    using System;
    using System.Data.SqlClient;
    using testThreadAbort.Properties;
    using System.Threading;
    using System.Diagnostics;
    
    namespace testThreadAbort
    {
        class Program
        {
            static AutoResetEvent evReady = new AutoResetEvent(false);
            static long xactId = 0;
    
            static void ThreadFunc()
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.conn))
                {
                    conn.Open();
                    using (SqlTransaction trn = conn.BeginTransaction())
                    {
                        // Retrieve our XACTID
                        //
                        SqlCommand cmd = new SqlCommand("select transaction_id from sys.dm_tran_current_transaction", conn, trn);
                        xactId = (long) cmd.ExecuteScalar();
                        Console.Out.WriteLine("XactID: {0}", xactId);
                        
                        cmd = new SqlCommand(@"
    insert into test (a) values (1); 
    waitfor delay '00:01:00'", conn, trn);
    
                        // Signal readyness and wait...
                        //
                        evReady.Set();
                        cmd.ExecuteNonQuery();
    
                        trn.Commit();
                    }
                }
    
            }
    
            static void Main(string[] args)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(Settings.Default.conn))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(@"
    if  object_id('test') is not null
    begin
        drop table test;
    end
    create table test (a int);", conn);
                        cmd.ExecuteNonQuery();
                    }
    
                    
                    Thread thread = new Thread(new ThreadStart(ThreadFunc));
                    thread.Start();
                    evReady.WaitOne();
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                    Console.Out.WriteLine("Aborting...");
                    thread.Abort();
                    thread.Join();
                    Console.Out.WriteLine("Aborted");
    
                    Debug.Assert(0 != xactId);
    
                    using (SqlConnection conn = new SqlConnection(Settings.Default.conn))
                    {
                        conn.Open();
    
                        // checked if xactId is still active
                        //
                        SqlCommand cmd = new SqlCommand("select count(*) from  sys.dm_tran_active_transactions where transaction_id = @xactId", conn);
                        cmd.Parameters.AddWithValue("@xactId", xactId);
    
                        object count = cmd.ExecuteScalar();
                        Console.WriteLine("Active transactions with xactId {0}: {1}", xactId, count);
    
                        // Check count of rows in test (would block on row lock)
                        //
                        cmd = new SqlCommand("select count(*) from  test", conn);
                        count = cmd.ExecuteScalar();
                        Console.WriteLine("Count of rows in text: {0}", count);
                    }
                }
                catch (Exception e)
                {
                    Console.Error.Write(e);
                }
    
            }
        }
    }
