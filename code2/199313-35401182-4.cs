    protected void gvLocationBoard_PreRender(object sender, EventArgs e)
    {
        GridView gv = (GridView)sender;
        int wsPos = 3;
        for (int wsCol = 0; wsCol < 19; wsCol++)
        {
            gv.Columns[wsCol + wsPos].HeaderText = "RollCallPeriod" + wsCol.ToString("{0,00}");
            gv.Columns[wsCol + wsPos].Visible = false;
        }
    }
