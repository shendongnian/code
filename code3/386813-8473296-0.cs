    protected void Button3_Click(object sender, EventArgs e)
    {
        ** if (Session["Clicked"] == null)
            Session["Clicked"] = true;
        else
        {
            Button3.Enabled = false;
            return;
        } **
        if (Session["login"] != null && Session["db"] != null)
        {
    
            digit b = new digit();
            String digitformed = b.formdigit(this.DropDownList1, this.TextBox1, this.TextBox2);
    
            chekcount c = new chekcount();
            int count = c.getmaxcountforjud_no(digitformed);
            int addtocount = count + 1;
    
            String name = Session["login"].ToString();
            String databs = Session["db"].ToString();
            String complex_name = name + databs;
    
            if (DropDownList2.SelectedItem.Text != "New")
            {
                update u = new update();
                u.update1(this.Editor1, digitformed, this.TextBox3, complex_name, name, this.DropDownList2);
                Response.Write(@"<script language='javascript'>alert('Updated')</script>");
    
            }
            else
            {
                save d = new save();
                d.dosave(this.Editor1, addtocount, digitformed, this.TextBox3, complex_name, name);
                Response.Write(@"<script language='javascript'>alert('Saved')</script>");
    
            }
        }
        else
        {
            Response.Redirect("log.aspx");
        }
    }
