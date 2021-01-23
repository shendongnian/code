        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Creates a list of alerts and binds them to the list view.
                // You would use your sql data reader here instead.  You could convert the data
                // into a list or just bind the data reader directly to the list view.  If you
                // bind the data reader to the list view then be sure to update the Eval statements
                // in the list view templates.
                var alerts = new[]
                {
                    new { AlertId = 1, AlertText = "This is alert #1."},
                    new { AlertId = 2, AlertText = "This is the second alert."},
                    new { AlertId = 3, AlertText = "This is the third alert."},
                    new { AlertId = 5, AlertText = "This is alert #5."}
                };
                listView.DataSource = alerts;
                listView.DataBind();
            }
        }
        protected void OkButton_Click(object sender, EventArgs e)
        {
            // get the list of alerts that have been checked
            var checkedAlerts = new List<int>();
            foreach (var listViewItem in listView.Items)
            {
                var checkbox = (CheckBox)listViewItem.FindControl("AlertChecked");
                if (checkbox.Checked)
                {
                    checkedAlerts.Add((int)listView.DataKeys[listViewItem.DataItemIndex].Value);
                }
            }
            // now do something to record them as read; we'll just display them in a label for this sample.
            lblDisplay.Text = "The following alerts were marked read: " + String.Join(",", checkedAlerts);
        }
