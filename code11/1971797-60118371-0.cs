    using(var conn = new MySqlConnection())
    {
        conn.ConnectionString = connString;
        conn.Open();
        string queryssxxxqbb = "Select * from products where deleted='No'";
        MySqlCommand cmdaaxxxqbb = new MySqlCommand(queryssxxxqbb, conn);
        MySqlDataReader dataReaderxxxxxqbb = cmdaaxxxqbb.ExecuteReader();
        while (dataReaderxxxxxqbb.Read())
        {
            var productname = dataReaderxxxxxqbb["productname"].ToString();
            var productprice = dataReaderxxxxxqbb["productprice"].ToString();
            var picturelink = dataReaderxxxxxqbb["picturelink"].ToString();
            try
            {
                this.imageList1.Images.Add(Image.FromFile(@"\\" + 
                    Properties.Settings.Default.Local_Server + 
                    "\\Documents\\Stock And Inventory Software\\Product Pictures\\" + 
                    picturelink));
            }
            catch
            {
                this.imageList1.Images.Add(Properties.Resources.default_image);
            }
            this.listView1.View = View.LargeIcon;
            this.imageList1.ImageSize = new Size(100, 90);
            this.listView1.LargeImageList = this.imageList1; 
            
            var item = new ListViewItem();       
            item.Text = productname;
            item.BackColor = Color.White;
            item.ImageIndex = j;
            listView1.Items.Add(item);
        }
    }
