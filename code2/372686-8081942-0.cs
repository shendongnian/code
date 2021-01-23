    protected void Page_Load(object sender, EventArgs e)
    {
        string id = "#info";
        string messageInfo = "le dossier a été crée avec succès";
    
        BtnEnregistrer.OnClientClick = String.Format("afficherMessageInfo('{0}','{1}')", id, messageInfo);
    
    }
