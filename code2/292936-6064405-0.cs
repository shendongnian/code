    myStreamReader = new System.IO.StreamReader(
        new System.IO.StreamReader(
            myHttpConn.GetResponse().GetResponseStream(),
            System.Text.Encoding.Default).BaseStream,
                 new System.IO.StreamReader(myHttpConn.GetResponse().GetResponseStream(),
                     System.Text.Encoding.Default).CurrentEncoding);
