     foreach (DataRow row in t.Rows)
    {
                    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(row["uri"].ToString());
                    myRequest.Method = "GET";
                    HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(myResponse.GetResponseStream());
                    myResponse.Close();
                    row["Img"] = bmp;
    }
