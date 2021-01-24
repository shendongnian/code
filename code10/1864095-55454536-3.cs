    private void populateItems()
    {
        string query = "SELECT * FROM Users";
        {
            using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
            {
                //Fill the DataTable with records from Table.
                DataTable dt = new DataTable();
                sda.Fill(dt);
                //Loop and add SelectUser:Usercontrol to FloyLayoutPanel.
                foreach (DataRow row in dt.Rows)
                {
                    SelectContacts contact = new SelectContacts();
                    contact.FirstName = row["FirstName"].ToString();
                    contact.LastName = row["LastName"].ToString();
                    contact.Title = row["Title"].ToString();
                    byte[] img = row["Image"] as byte[];
                    if(img != null && img.length > 0)
                    {
                        MemoryStream ms = new MemoryStream(img);
                        contact.PublicProfilePic = Image.FromStream(ms);
                    }
                    flowUsers.Controls.Add(contact);
                }
            }
        }
    }
