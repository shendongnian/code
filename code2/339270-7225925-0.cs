    bool OpenConn()
    {
      try
      {
         using(Conn = new SqlCeConnection(String.Format(@"Data Source={0}\{1}", PathI, "PC.SDF")))
         {
            Conn.Open();
            return true;
         }
       }
       catch 
       {
          //MessageBox.Show(err.Message, "Connetion error");
          return false;
       }
    }
    if (File.Exists(@"\myPath\PC.sdf"))
        File.Delete(@"\myPath\PC.sdf");
