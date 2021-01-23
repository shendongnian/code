    if (!DataHelper.DataSourceIsEmpty(dsUp))
                    {
                        //get datarow collection from dataset
                        DataRowCollection drc = dsUp.Tables[0].Rows;
                        //Loop through dataset
                        foreach (DataRow dr in drc)
                        {
                            //get current dataset row sortid
                            int sortID = Convert.ToInt32(dr["SortID"]);
                            { 
                            //if its the row above then minus one
                            if (sortID == nodeAbove)
                            {
                                int newID = Convert.ToInt32(dr["SortID"].ToString());
                                newID--;
                                dr["SortID"] = newID;
                                //TODO: save changes back to original ds
    
                            }
                            }
    
                        }
                      //you can save here as the dataset will keep track of all the changes
                      YourDataAdapter.Update("tableName",dsUp)
                    }
