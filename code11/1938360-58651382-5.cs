    public partial class Page2 : ContentPage, Interface1
    {
        public String PageText { get; set; }
        public Page2()
        {
            PageText =
            "The Persian learned men say that the Phoenicians were the cause " +
            "of the dispute. These (they say) came to our seas from the sea " +
            "which is called Red,1 and having settled in the country which " +
            "they still occupy, at once began to make long voyages. Among other " +
            "places to which they carried Egyptian and Assyrian merchandise, " +
            "they came to Argos";
            InitializeComponent();
            BindingContext = this;
        }
    }
