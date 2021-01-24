    private void GenerateTable()
        {
            SomerenLogic.Room_Service roomService = new SomerenLogic.Room_Service();
            List<Room> roomList = roomService.GetRooms();
            int counter = 0;
            foreach (SomerenModel.Room s in roomList)
            {
                counter = counter + 1;
            }
            double wortelvan = Math.Sqrt(counter);
            double column = Math.Floor(wortelvan);
            double row = Math.Ceiling(wortelvan);
            int columnCount = (int)(column);
            int rowCount = (int)(row);
            SomerenLogic.Indeling_Service indelingService = new SomerenLogic.Indeling_Service();
            
            //Clear out the existing controls, we are generating a new table layout
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            //Clear out the existing row and column styles
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            //Now we will generate the table, setting up the row and column counts first
            tableLayoutPanel1.ColumnCount = columnCount;
            tableLayoutPanel1.RowCount = rowCount;
            
            int counter2 = 1;
            for (int x = 0; x < columnCount; x++)
            {
                //First add a column
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent));
                for (int y = 0; y < rowCount; y++)
                {
                    //Next, add a row.  Only do this when once, when creating the first column
                    if (x == 0)
                    {
                        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent));
                    }
                    ////Create the control, in this case we will add a button
                    //Button cmd = new Button();
                    //cmd.Text = string.Format("({0}, {1})", x, y);         
                    ////Finally, add the control to the correct location in the table
                    
                    ListView listView1 = new ListView();
                    listView1.Columns.Add("");
                    
                    listView1.View = View.Details;
                    
                    listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
                    listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    listView1.Scrollable = false;
                    listView1.GridLines = true;
                    listView1.AutoArrange = true;
                    
                    List<Indeling> indelingList = indelingService.GetIndeling(counter2);
                    foreach (SomerenModel.Indeling s in indelingList)
                    {
                        ListViewItem la = new ListViewItem("Kamer nummer: "+(s.KamerNummer).ToString());
                        listView1.Items.Add(la);
                        ListViewItem lb = new ListViewItem("Type kamer: "+(s.TypeKamer).ToString());
                        listView1.Items.Add(lb);
                        ListViewItem lc = new ListViewItem("Plekken: "+(s.AantalBedden).ToString());
                        listView1.Items.Add(lc);
                        listView1.Height = (listView1.Items.Count * 19);
                        tableLayoutPanel1.Controls.Add(listView1, x, y);
                       
                        listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    }
                    
                    counter2++;
                }
            }
            
        }
