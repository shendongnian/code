    personViewModels.Select(p => 
        new PersonViewModel {
            Id = p.Id,
            DisplayName = p.DisplayName,
            Upn = p.Upn
        }
    );
