       if( ds.Tables[0].Rows[0][0] == DBNull.Value ) //which is working properly
            {
                        seqno  = 1; 
             }
                else
                {
                      seqno = Convert.ToInt16(ds.Tables[0].Rows[0][0]) + 1;
                 }
