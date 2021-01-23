             //append to csv file
             StreamWriter sw = File.AppendText("e:\\results\\decdiylayout.csv");
             //seperate datagrid to comma seperated values
             for (int i = 0; i < GridView1.Rows.Count; i++)
             {
                string strRowVal = "";
                for (int j = 0; j < GridView1.Rows[i].Cells.Count; j++)
                {
              
                    GridViewRow row = GridView1.Rows[i];
                    TextBox Qty = (TextBox)row.FindControl("TextBox2");
                    String Quant = Qty.Text;
                    if (strRowVal == "")
                    {
                        strRowVal = DateTime.Now + "," + username[1].Remove(3)+ "," + Layout.Text + "," + Quant + "," + GridView1.Rows[i].Cells[j].Text;
                    }
                    else
                    {
                        strRowVal =  strRowVal + "," + GridView1.Rows[i].Cells[j].Text;
                    }
                }
                sw.WriteLine(strRowVal);
            }
            sw.Close(); 
