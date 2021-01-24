    public class FirebaseHelper
       {
            FirebaseClient firebase = new FirebaseClient("https://MY_DATABASE_LINK.firebaseio.com/");
    
            public async Task<List<Person>> GetAllPersons()
            {
    
                return (await firebase
                  .Child("<table_name>") // should only be your table name,here should be 'users'
                  .OnceAsync<Person>()).Select(item => new Person
                  {
                      FName = item.Object.FName,
                      LName = item.Object.LName,
                      Age = item.Object.Age
                  }).ToList();
                }
    }
