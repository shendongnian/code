    public class Page1 : ContentPage //User input page
        {
            public static User user;
            public Page1()
            {
                
            }
    
            async void Clicked()
            {
                user = new User("username input", "password input");
            }
        }
