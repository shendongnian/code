        public class Users : ObservableCollection<User>
        {
            public Users()
            {
                Add(new User("Jamy", "James Smith", Count));
                Add(new User("Mairy", "Mary Hayes", Count));
                Add(new User("Dairy", "Dary Wills", Count));
            }
        }
