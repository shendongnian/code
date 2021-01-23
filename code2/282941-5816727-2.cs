     protected void DetailView1_ModeChanging(Object sender, DetailsViewModeEventArgs e)
        {
            if (e.NewMode == DetailsViewMode.Edit)
            {
                DetailsView1.ChangeMode(e.NewMode);
                DetailsView1.Datebind(); // add this and check
            }
            if (e.CancelingEdit)
            {
                DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);   
                DetailsView1.Datebind(); // add this and check
            }
        }
