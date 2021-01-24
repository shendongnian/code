    public partial class Page1 : ContentPage,Interface1
    {
        public String PageText { get; set; }
        public Page1()
        {
            
            PageText =
               "This is the display of the inquiry of Herodotus of Halicarnassus, " +
               "so that things done by man not be forgotten in time, and that great " +
               "and marvelous deeds, some displayed by the Hellenes, some by the " +
               "barbarians, not lose their glory, including among others what was the " +
               "cause of their waging war on each other. ";
            InitializeComponent();
            BindingContext = this;
        }
    }
