        protected override void InitializeCulture()
        {
            if (Session["LCID"] != null)
            {
                int lcid = (int)Session["LCID"];
                CultureInfo c = new CultureInfo(lcid);
                Thread.CurrentThread.CurrentCulture = c;
            }
            base.InitializeCulture();
        }
        protected void comboCultures_SelectedIndexChanged(object sender, EventArgs e)
        {
            CultureInfo c = new CultureInfo(Thread.CurrentThread.CurrentCulture.LCID);
            if (comboCultures.SelectedItem != null)
                c = CultureInfo.GetCultureInfo(Convert.ToInt32(comboCultures.SelectedItem.Value));
            Session["LCID"] = c.LCID;
            Server.Transfer("Default.aspx");
        }
