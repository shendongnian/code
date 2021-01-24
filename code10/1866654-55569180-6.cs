    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
    namespace zzWpfApp1
    {
        class MainWindowViewModel
        {
            public ObservableCollection<User> Users { get; set; }
    
            public MainWindowViewModel()
            {
                List<User> users = new List<User>();
                users.Add(new User() {Name = "Donald Duck", HairColor = HairColor.White});
                users.Add(new User() {Name = "Mimmi Mouse", HairColor = HairColor.Red});
                users.Add(new User() {Name = "Goofy", HairColor = HairColor.Brown});
                Users = new ObservableCollection<User>(users);
            }
        }
    }                       
    
