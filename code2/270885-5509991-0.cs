    SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ims"].ConnectionString);
     Conn.Open();
     DataSet ds1 = new DataSet();
     string querry = "Select po_tax from purchase_order where po_id='" + Request.QueryString["po_id"] + "'";
    
     // ds1 = obj1.SelectQuery(querry);
     SqlCommand cmd = new SqlCommand(querry,Conn);
     cmd.ExecuteNonQuery();
    
     SqlDataReader rdr;
    
     rdr = cmd.ExecuteReader();
     if (!rdr.Read())
     {
          //No Records
          rdr.Close();
          Conn.Close();
          Label3.Text = "No record found";
          return;
     }
     else
     {
          CheckBoxList chkbx = (CheckBoxList)form1.FindControl("CheckBoxList1");
          rdr.NextResult();
          if (rdr.IsClosed == false)
          {
              do                       //Dont place 'while' here coz u already used it in above if loop
               {
                    ListItem currentCheckBox = chkbx.Items.FindByValue(rdr["po_id"].ToString());
                    if (currentCheckBox != null)
                    {
                         currentCheckBox.Selected = true;
                    }
               } while (rdr.Read())
          }
          rdr.Close();
          //string[] items = returned_value_from_db.Split(',');
          string[] items = sb.ToString().Split(',');
          for (int i = 0; i <= items.GetUpperBound(0); i++)
          {
               ListItem currentCheckBox = chkbx.Items.FindByValue(items[i].ToString());
               if (currentCheckBox != null)
               {
                    currentCheckBox.Selected = true;
               }
          }
     }
    
     Conn.Close();
