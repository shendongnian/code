    private void SizeLastColumn(ListView lv)
    {
     int x = lv.Width/15 == 0 ? 1 : lv.Width/15;
     lv.Columns[0].Width = x*2; 
     lv.Columns[1].Width = x;
     lv.Columns[2].Width = x*2;
     lv.Columns[3].Width = x*6;
     lv.Columns[4].Width = x*2;
     lv.Columns[5].Width = x*2;
    }
