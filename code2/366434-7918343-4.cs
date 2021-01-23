    public class when_discriminating_on_subclass
    {
       static IList<FileConversion> results;
       Establish context = () =>
       {
          using (var session = DataConfiguration.CreateSession())
          {
             using (var transaction = session.BeginTransaction())
             {
                var upload = new UploadedFileDocument 
                                 { Name = "uploaded", ContentType = "test" };
                var form = new ApplicationFormDocument 
                                 { Name = "afd" };
                session.Save(form);
                session.Save(upload);
                var formConversion = 
                    new FileConversion { DocumentType = form };
                var uploadConversion = 
                    new FileConversion { DocumentType = upload };
                session.Save(formConversion);
                session.Save(uploadConversion);
                transaction.Commit();
             }
             using (var transaction = session.BeginTransaction())
             {
                results = session.Query<FileConversion>().AsQueryable().ToList();
                transaction.Commit();
             }
         }
      };
