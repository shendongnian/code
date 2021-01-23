    //Loop through each row and insert into database
                    int i = 0;
                    foreach (DataRow row in TempRouteDataTable.Rows)
                    {
                        //Gather column headers
                        var category = Convert.ToString(CategoryDDL.SelectedItem);
                        var agency = Convert.ToString(row["Agency"]);
                        var route = Convert.ToString(row["Route"]);
                        var direction = Convert.ToString(row["Direction"]);
                        var serviceKey = Convert.ToString(row["Service Key"]);
                        var language = Convert.ToString(row["Language"]);
                        var activeServiceKeys = Convert.ToString(row["Active Service Keys"]);
                        var origID = -1;
    
                        if (GetActiveServiceKeys.Rows.Count > 0)
                        {
                            origID = Convert.ToInt32(GetActiveServiceKeys.Rows[i]["ActiveServiceKeysID"]);
                            var GetID = (SEPTA_DS.ActiveServiceKeysTBLDataTable)askta.GetDataByID(origID);
                            if (GetID.Rows.Count < 1)
                            {
                                origID = -1;
                            }
                        }
    
                        if (origID == -1)
                        {
                            int insertData = Convert.ToInt32(askta.InsertActiveServiceKeys(category, agency, route, direction, serviceKey, language, activeServiceKeys));
                        }
                        else
                        {
                            int updateData = Convert.ToInt32(askta.UpdateActiveServiceKeys(category, agency, route, direction, serviceKey, language, activeServiceKeys, origID));
                        }
                        i++;
                     }
