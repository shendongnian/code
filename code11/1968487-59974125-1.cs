    public ICommand UsunCommand { get { return new RelayCommand<ObiektyForAllViews>(OnEdit); } }
    private void OnEdit(ObiektyForAllViews itemToEdit)
    {
        int idObiektu = itemToEdit.idObiektu;
        atmaEntites.Database.ExecuteSqlCommand("UPDATE Obiekty SET stan = '2' WHERE idObiektu = " + idObiektu + ";");
    }
