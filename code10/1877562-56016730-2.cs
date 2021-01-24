            protected void Page_Load(object sender, EventArgs e)
            {
                if (Convert.ToBoolean(uiRemoved.Value))
                {
                    this.Visible = false;
                }
                this.uiDistance.Text = "123"; // it will assign when page loads.
            }
