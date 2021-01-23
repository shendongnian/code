            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "text/plain";
           
            foreach (Control ctrl in this.Form.Controls)
            {
                //Response.Write("ID: " + ctrl.ID + "\n");
                //Response.Write("ClientID: " + ctrl.ClientID + "\n");
                if ((ctrl as ContentPlaceHolder) != null)
                {
                    ContentPlaceHolder chp = ctrl as ContentPlaceHolder;
                    Response.Write("Content Found" + "\n");
                    foreach (Control control in chp.Controls)
                    {
                        string strID = control.ID;
                        Response.Write("Control in content: " + strID + "\n");
                        //do stuff based on the the ID
                    }
                }
            }
            Response.End();` 
