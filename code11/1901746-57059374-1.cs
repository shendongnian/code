    public class SomeController : ApiController
    {
        [DecryptRequestContent]
        public void SomeMethod(DataModel model)
        {
            // implementation goes here
        }
    }
