    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                foreach (Control ctrl in Form.Controls)
                {
                    if (ctrl is ContentPlaceHolder)
                    {
                        ContentPlaceHolder chp = ctrl as ContentPlaceHolder;
                        foreach (Control control in chp.Controls)
                        {
                string strID = control.UniqueID;
                //do stuff based on the the ID
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
