    protected void Page_Load(object sender, EventArgs e)
    {
        contentID = Convert.ToInt32(Request.QueryString["contentid"]);
        if (contentID != 0)
        {
            if (!this.IsPostBack)
            {
                getContentBody(contentID);
                TextBox1.Text = content;
                msg_lbl.Text = "Inside not PostBack";
            }
        }
        else
            Response.Write("Invalid URL for article");
    }
    public void getContentBody(int contentID)
    {
        try
        {
            //////////////Opening the connection///////////////
            mycon.Open();
            string str = "select content from content where contentID='" + contentID + "'";
            //Response.Write(str);
            MySqlCommand command1 = mycon.CreateCommand();
            command1.CommandText = str;
            dr = command1.ExecuteReader();
            if (dr.Read())
            {
                content = dr[0].ToString();
            }
        }
        catch (Exception ex)
        {
            Response.Write("Exception reading data" + ex);
        }
        finally
        {
            dr.Close();
            mycon.Close();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //string textboxvalue = Request.Form[TextBox1.UniqueID];
        mycon.Open();
        string query = "update content set content='" + TextBox1.Text + "' where contentID= '" + contentID + "'";
        msg_lbl.Text = query;
        try
        {
            MySqlCommand command1 = mycon.CreateCommand();
            command1.CommandText = query;
            command1.ExecuteNonQuery();
            getContentBody(contentID);
            TextBox1.Text = content;
            msg_lbl.Text = "text" + TextBox1.Text;
        }
        catch (Exception ex)
        {
            msg_lbl.Text = "Exception in saving data" + ex;
        }
        finally
        {
            mycon.Close();
        }
    }
