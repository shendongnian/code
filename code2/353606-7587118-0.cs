    List<string> ids = new List<string>();
    for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    int bookID = (int)GridView1.DataKeys[i][0];
                    CheckBox cb = (CheckBox)GridView1.Rows[i].FindControl("CheckBox");
                    if (cb.Checked)
                    {
                        purchaseProductList.Add(bookID);
                        ids.Add(bookID);
                    }
           }
    
    session["Ids"] = ids;
    
    Response.Redirect("SecondPage.aspx"); 
