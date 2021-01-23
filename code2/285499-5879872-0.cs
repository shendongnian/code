                while (dr.Read())
                {
                    ...
                    listView1.Items.Add(itmX);
                    if (dr.GetDateTime(2) > dr.GetDateTime(3))
                    {
                        itmX.SubItems.Add("Expired");
                    }
                }
