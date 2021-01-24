    Loaded += delegate
    {
        PropertyChangedEventHandler propertyChanged = delegate
	    {
            //if number of checked items != 3
                //return;
            //update agents
        };
        foreach (var etablissement in EtablissementsUtilisateur)
            etablissement.PropertyChanged += propertyChanged;
    }
