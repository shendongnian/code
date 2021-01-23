    public class GiftCertificateService 
    {
       public void CreateCertificate() 
       {
          //Do whatever needs to create a certificate.
          GiftCertificateRepository gcRepo = new GiftCertificateRepository();
          GiftCertificateModel gc = gcRepo.CreateNew();
          gc.Amount = 10.00M;
          gc.ExpirationDate = DateTime.Today.AddMonths(12);
          gc.Notes = "Test GC";
          gcRepo.Save(gc);
       }
    }
