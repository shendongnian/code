    using Library = Project.Library;
    
    namespace Project.Service
    {
         public class User
         {
              public int GetUserId()
              {
                  Library.User myLibUser = new Library.User();
                  return myLibUser.Id;
              }
         }
    }
