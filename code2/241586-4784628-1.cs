    public class UserService {
        private DbContext Context {get; set;}
    
        public IList<Document> GetUserDocument(User user)
        {
            // Assuming User table does not have a Document ID as a foregin key..
            // Do whatever you need to do to get document.
        } }
