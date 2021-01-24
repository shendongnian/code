    namespace BlazorApp.Models
    {
        public class TestViewModel
        {
            public string Search { get; set; }
    
            public async void SearchChanged()
            {
                // Break point set but not hit?
                Search = "Hello world";            
            }
        }
    }
