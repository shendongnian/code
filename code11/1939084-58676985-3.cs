    public class Page2 : ContentPage
    {
        public Page2(User user)
        {
            //Here you can access the user variable
            user.Email = "Some other input";
        }
    }
