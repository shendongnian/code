     protected void Button1_Click(object sender, EventArgs e)
            {
                var rec = (from r in dc.Customers
    
                           where r.cust_Login == txtname.Text.Trim() && r.cust_Pwd == txtPass.Text.Trim()
                           select r).SingleOrDefault();
    
    
                var depart = (from de in dc.Departments
                              where de.dept_Id == rec.cust_Dept
                              select de).Single();
    
                if (rec != null && rec.cust_Agent == true)
               
                {
    
                    Session["txtname"] = txtname.Text;
                    Session["txtDepartment"] = depart.dept_Id;
                    **Session["cid"] = rec.cust_Id;**
    
                    Response.Redirect("response.aspx");
                }
    
                else {
                    Response.Write("invalid");
                }
            }
