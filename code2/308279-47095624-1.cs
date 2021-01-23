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
                
