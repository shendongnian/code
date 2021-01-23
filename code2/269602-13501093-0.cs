     #region Remove Not allowed from Table
    
                    foreach (DataRow dr1 in dtCMATM.Select())
                    {
                        foreach (DataRow dr2 in dt.Rows)
                        {
                            if (dr1[1].ToString() == dr2[0].ToString())
                            {
                                dr2.Delete();
                                break;
                            }
                            else
                            {
                                dr1.Delete();
                                break;
                            }
                        }
                        dt.AcceptChanges();
                    }
    
                    dtCMATM.AcceptChanges();
    
                    #endregion
