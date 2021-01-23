    DataTable allTracks = tracks.getByMedia();
        foreach(DataRow r in allTracks.Rows) {
            
            string track_number= r["track_number"]!=System.DBNull.Value?r["track_number"].ToString():"";
            string track_name=r["track_name"]!=System.DBNull.Value?r["track_name"].ToString():"";
            ListViewItem lvi = new ListViewItem();
            lvi.Text = track_number;
            lvi.SubItems.Add(track_name);
            lvTracks.Items.Add(lvi);
        }
