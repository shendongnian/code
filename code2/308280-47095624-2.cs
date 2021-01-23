    //Data Table
    
     protected DataTable tblDynamic
            {
                get
                {
                    return (DataTable)ViewState["tblDynamic"];
                }
                set
                {
                    ViewState["tblDynamic"] = value;
                }
            }
    //DynamicReport_GetUserType() function for getting data from DB
    
    
    System.Data.DataSet ds = manage.DynamicReport_GetUserType();
                    tblDynamic = ds.Tables[13];
    
    //Add Column as "TypeName"
    
                    tblDynamic.Columns.Add(new DataColumn("TypeName", typeof(string)));
    
    //fill column data against ds.Tables[13]
    
    
                    for (int i = 0; i < tblDynamic.Rows.Count; i++)
                    {
    
                        if (tblDynamic.Rows[i]["Type"].ToString()=="A")
                        {
                            tblDynamic.Rows[i]["TypeName"] = "Apple";
                        }
                        if (tblDynamic.Rows[i]["Type"].ToString() == "B")
                        {
                            tblDynamic.Rows[i]["TypeName"] = "Ball";
                        }
                        if (tblDynamic.Rows[i]["Type"].ToString() == "C")
                        {
                            tblDynamic.Rows[i]["TypeName"] = "Cat";
                        }
                        if (tblDynamic.Rows[i]["Type"].ToString() == "D")
                        {
                            tblDynamic.Rows[i]["TypeName"] = "Dog;
                        }
                    }
                
