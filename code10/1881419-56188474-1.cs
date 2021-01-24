    List<SortingRepresentation> sortingFields = new List<SortingRepresentation>();
    public Form1()
    {
        sortingFields.Add(new SortingRepresentation{ Field = SortField.All, DisplayLabel = "All", TypeCriterion = typeof(Client)    });
        sortingFields.Add(new SortingRepresentation{ Field = SortField.A, DisplayLabel = "Only Retail", TypeCriterion = typeof(Client_A)  });
        sortingFields.Add(new SortingRepresentation{ Field = SortField.B, DisplayLabel = "Only Wholesale", TypeCriterion = typeof(Client_B)  });
        sortingFields.Add(new SortingRepresentation { Field = SortField.C, DisplayLabel = "Only Human Wholesale", TypeCriterion = typeof(Client_C) });
        cBox.DisplayMember = "DisplayLabel";
        cBox.DataSource = sortingFields;
    }
