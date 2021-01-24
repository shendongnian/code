       public class Firebasehelper
    {
        FirebaseClient firebase;
        public Firebasehelper()
        {
            firebase = new FirebaseClient("https://fir-databasedemo-62a72.firebaseio.com/");
        }
       
        public async Task AddUser(int userid, string first_name, string last_name, string password)
        {
            await firebase
              .Child("Users")
              .PostAsync(new User() { userid = userid, first_name = first_name, last_name= last_name, password= password });
        }
        public async Task<List<User>> GetAllUsers()
        {
            return (await firebase
              .Child("Users")
              .OnceAsync<User>()).Select(item => new User
              {
                  userid = item.Object.userid,
                  first_name = item.Object.first_name,
                  last_name = item.Object.last_name,
                  password = item.Object.password
              }).ToList();
        }
    }
