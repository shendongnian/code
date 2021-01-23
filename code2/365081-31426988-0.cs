    DataSet dsAct = new DataSet();
    
    OleDbDataAdapter odaTem = new OleDbDataAdapter("SELECT ActivityId, Activity FROM tbl_Activity", ocnConn);
                        
    odaTem.Fill(dsAct, "Activity");
    
    DataRow drTem;
                        
    int i = 0;
    
    //Rows want set to be on top is in the table "TopActivity"
                        
    foreach (DataRow dr in dsAct.Tables["TopActivity"].Rows)
                    
    {
                            
    drTem = dsAct.Tables["Activity"].NewRow();
                            
    //Clone the row
    
    drTem.ItemArray = dsAct.Tables["Activity"].Rows.Find(dr["Activity_ID"]).ItemArray;
                            
    dsAct.Tables["Activity"].Rows.RemoveAt(  dsAct.Tables["Activity"].Rows.IndexOf( dsAct.Tables["Activity"].Rows.Find(dr["Activity_ID"])));
                            
    dsAct.Tables["Activity"].Rows.InsertAt(drTem, i);
                            
    i++;
                        
    }
