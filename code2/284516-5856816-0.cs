            private void FillCar()
            {      
                DataTable dt = GetCar();
                ddl1.Items.Clear();
                ddl1.DataSource = dt;
                ddl1.DataTextField = "carName"; // field name in the database
                ddl1.DataValueField = "CarNum"; // field name in the database
                ddl1.DataBind();
                ListItem li = new ListItem();
                li.Text = "--Choose car--";
                li.Value = "-1";
                ddl1.Items.Insert(0, li);
                ddl1.SelectedIndex = 0;
            }
