    private void SizeLastColumn(ListView lv)
    {
     int x = ListView.Width/15 == 0 ? 1 : ListView.Width/15;
     listView1.Columns[0].Width = x*2; 
     listView1.Columns[1].Width = x;
     listView1.Columns[2].Width = x*2;
     listView1.Columns[3].Width = x*6;
     listView1.Columns[4].Width = x*2;
     listView1.Columns[5].Width = x*2;
    }
