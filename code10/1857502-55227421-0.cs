            public void PlantList_with_images(string value)
            {
                flowLayoutPanelPlantList.Controls.Clear();
    
                //Create a task to gather your controls. 
                //Inside of a task the UI will still continue to respond when gathering your controls
                //Change it from add 1 control at a time to AddRange after you have gathered your controls
                flowLayoutPanelPlantList.Controls.AddRange(Task.Run(() =>
                {
                    List<Button> controlList = new List<Button>();
    
                    try
                    {                    
                        string expression;
                        string sql;
                        expression = " select [id],[code],[name] from [plantdetails] where categoryname ='" + value + "'";
                        Datatable dt = DataAccess.GetTable(sqlfetcher);
                        int currentImage = 0;
    
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow dataReader = dt.Rows[i];
    
                            Button b = new Button();
                            b.Tag = dataReader["name"].ToString();
                            b.Click += new EventHandler(b_Click_Plant);
    
                            string details = dataReader["code"].ToString() +
                            "\n Name: " + dataReader["name"].ToString();
    
                            b.Name = details;
    
                            ImageList il = new ImageList();
                            il.ColorDepth = ColorDepth.Depth32Bit;
                            il.TransparentColor = Color.Transparent;
                            il.ImageSize = new Size(58, 60);
                            il.Images.Add(Image.FromFile(img_directory + dataReader["imagename"]));
    
                            b.Image = il.Images[0];
                            b.Margin = new Padding(0, 0, 0, 0);
    
                            b.Size = new Size(190, 83);
                            //b.Text.PadRight(4);
    
                            b.Text += dataReader["code"].ToString();
                            b.Text += "\n" + dataReader["name"].ToString();
    
                            b.Font = new Font("Arial", 8, FontStyle.Bold, GraphicsUnit.Point);
                            b.TextAlign = ContentAlignment.MiddleLeft;
                            b.TextImageRelation = TextImageRelation.ImageBeforeText;
                            //flowLayoutPanelPlantList.Controls.Add(b);
                            controlList.Add(b);
                            currentImage++;
    
                        }
                    }
                    catch //(Exception)
                    {
                    }
    
                    //Return the list of controls
                    return controlList;
                    //When you return the controls you will get a pause when adding all the controls to the flowcontainer it is unavoidable.
                }));
            }
