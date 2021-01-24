    [QueryProperty("Test", "test")]
    public partial class AboutPage : ContentPage
    {
     string test;
     public string Test
        {
            set =>test = Uri.UnescapeDataString(value); 
            get => test;
         
        }
    }
      
