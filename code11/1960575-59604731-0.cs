    public IEnumerable<ComboboxKeyAndValue> MenagerzyComboboxItems
    {
        get
        {
            return
            (
                from menagerzy in atmaEntites.Menagerzy
                select new ComboboxKeyAndValue
                {
                    Key = menagerzy.idMenagera,
                    Value = menagerzy.nazwa + " " + menagerzy.imie + " " + menagerzy.nazwisko,
                }
            ).ToList();
        }
    }
