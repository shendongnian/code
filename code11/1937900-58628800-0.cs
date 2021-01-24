    private int nbr_object;
    public int Nbr_objet_property
    {
        get { return nbr_objet; }
        set
        {
            nbr_objet = value;
            OnPropertyChanged(nameof(Nbr_objet_property));
        }
    }
