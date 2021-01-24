    private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
    {
        if (e.Column = <yourColumn>)
        {
            e.DisplayText = (long) e.Value == 1 ? "Yes" : "No";
        }
    }
