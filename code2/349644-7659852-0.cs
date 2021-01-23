    protected void UpdateDataSource(object sender, EntityDataSourceChangingEventArgs e)
    {
        if (!gruppoAdmin.Contains("SPGAdmins"))
        {
            SalesPortalModel.PianificazioneIncontri pianificazione = e.Entity as SalesPortalModel.PianificazioneIncontri;
            int idCommerciale = (from a in entity.Commerciali where a.Nome == Context.User.Identity.Name select a.IDCommerciale).First();
            pianificazione.IDCommerciale = idCommerciale;
            detailsView1.Rows[1].Visible = false;
        }
    }
