    GiftCertificateRepository gcRepo = new GiftCertificateRepository();
    GiftCertificateModel gc = gcRepo.CreateNew();
    gc.Amount = 10.00M;
    gc.ExpirationDate = DateTime.Today.AddMonths(12);
    gc.Notes = "Test GC";
    gcRepo.Save(gc);
    int Id = gc.Id; // Save populate the Id
