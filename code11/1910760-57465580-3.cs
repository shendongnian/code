    public class UserViewModel
        {
            public string Name { get; set; }
            public int Age { get; set; }
    
            public UserViewModel(int age, string name)
            {
                this.Age = age;
                this.Name = name;
            }
    
            public async Task<int> GetAge()
            {
                return this.Age;
            }
    
    
            public async Task<string> GetName()
            {
                return this.Name;
            }
    
        }
