        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/json";
            string NameToLookUp = Request.QueryString["username"];
            if (NameToLookUp == null) {
                NameToLookUp = "";
            }
            DbaseExecSpWithReturnValue Sproc = new DbaseExecSpWithReturnValue();
            Sproc.SetSp("sp_CheckUsernameAvailable");
            Sproc.AddParam(1);
            Sproc.AddParam("Username",SqlDbType.Char,NameToLookUp,20);
            int RetVal = Sproc.Execute();
            Sproc.Close();
            if (RetVal == 0)
            {
                Response.Write(@"'{""success"": false}'");
            }
            if (RetVal == 1)
            {
                Response.Write(@"'{""success"": true}'");
            }
            Response.End();
        }
