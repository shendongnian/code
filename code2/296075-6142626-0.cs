        public class GiftCertificateModel
        {
        }
        public class GiftCertificateRepository
        {
           //Remove Model related code from here, and just put ONLY database specific code here, (no business logic also). Common methods would be Get, GetById, Insert, Update etc. 
  
            Since essence of Repository is to have common CRUD logic at one place soyou don't have to write entity specific code. 
            You will create entity specific repository in rare cases, also by deriving base repository.
           
        }
        public class GiftCertificateService()
        {
            //Create Model instance here
            // Use repository to fill the model (Mapper)
                    
        }
  
