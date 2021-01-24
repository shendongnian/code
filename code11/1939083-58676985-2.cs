    public class Page1 : ContentPage //User input page
        {
            public Page1()
            {
                
            }
    
            async void Clicked()
            {
                User user = new User("username input", "password input");
                Navigation.PushAsync(new Page2(user));
            }
        }
