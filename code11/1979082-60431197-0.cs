    void GenerateButton(FlowLayoutPanel pnl)
            {
                Button CategoryButton = new Button
                {
                    Enabled = true,
                    Text = ItemName,
                    BackColor = Color.Green,
                    ForeColor = Color.White,
                    Width = 150,
                    Height = 50,
                    Name = ItemName,
                    Font = new Font("Georgia", 12)
                };
    
                void SearchItemsInThisCategory(object sender , EventArgs e)
                {
                    foreach(Button button in pnl.Controls.OfType<Button>())  //Remove others categories buttons
                    {
                        if (button.Name != CategoryButton.Name)
                        {
                            pnl.Controls.Remove(button);
                        }
                    }
                    using (SqlConnection con = new SqlConnection("Data Source=Shezi;Initial Catalog=RMS;Integrated Security=True"))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter($"select {CategoryButton.Text} From MenuItems", con);
                        DataTable dt = new DataTable();
                        dataAdapter.Fill(dt);
    
    
                        foreach (DataRow row in dt.Rows)
                        {
                            ItemName = row[CategoryButton.Text].ToString(); 
                            GenerateButton(pnl);
                        }
    
                    }
    
                }
                CategoryButton.Click += SearchItemsInThisCategory;
                pnl.Controls.Add(CategoryButton);
            }
    
            public void GetAllCategories(FlowLayoutPanel pnl)
            {
                using (SqlConnection con = new SqlConnection("Data Source=Shezi;Initial Catalog=RMS;Integrated Security=True"))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("select Categories From Categories", con);
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);
    
    
                    foreach (DataRow row in dt.Rows)
                    {
                        ItemName = row["Categories"].ToString(); //Assume Categories columns contains all categories
                        GenerateButton(pnl);
                    }
    
                }
    
            }
