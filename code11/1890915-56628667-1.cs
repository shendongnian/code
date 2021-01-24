     Response.Write("<b>Welcome : </b>  " +Session["txtname"].ToString());
                Response.Write("<br/><b>Department : </b>  " + Session["txtDepartment"].ToString());
                Response.Write("<br/>Customer ID :" +Session["cid"].ToString());
 
    protected void Button1_Click(object sender, EventArgs e)
            {
          
            
    
                Session["cid"].ToString();
                var customerID = (Session["cid"].ToString());
    
    
    
              
                {
                    var test11 = (from u in dc.ComplaintComments
    
                                  join b in dc.Complaints on u.comp_Id equals b.comp_Id
                                  join g in dc.ComplaintPriorities on u.cp_id equals g.cp_Id
                                  join m in dc.ComplaintStatus on u.cs_Id equals m.cs_Id
                                  join t in dc.ComplaintTypes on b.comp_Type equals t.ct_Id
                                  join a in dc.Customers on u.cust_Id equals a.cust_Id
                                  join x in dc.Departments on a.cust_Dept equals x.dept_Id
    
                                  where a.cust_Id == Convert.ToInt32(Session["cid"].ToString())
                                  orderby u.comp_Id ascending
                                  select new
    
                                  {
                                      b.comp_Id,
                                      Ticket_Date = b.comp_Date_time,
                                      Issue_Type = t.ct_Name,
                                      Last_Modification = u.cc_Timestamp,
                                      Assigned_To = a.cust_FirstName,
                                      Priority = g.cp_Desc,
                                      Status = m.cs_Name,
                                      Comments = u.cc_Comments,
                                      x.dept_Name
                                  }
    
                                          ).GroupBy(item => item.comp_Id)
    
                                         .Select(item => item.ToList().First());
    
                    GVTesting.DataSource = test11;
                    GVTesting.DataBind();
                }
