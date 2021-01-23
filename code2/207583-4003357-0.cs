    public class DinnerFormViewModel
    {
        private static string[] _countries = new[] {
            "USA",
            "UK",
            "IRL",
            "SA"
        };
        //Properties
        public Dinner Dinner { get; private set; }
        // will hold the selected country value
        public string SelectedCountry { get; set; }
        public SelectList Countries { get; private set; }
        //Constructor
        public DinnerFormViewModel(Dinner dinner)
        {
            Dinner = dinner;
            Countries = new SelectList(_countries, dinner.Country);
        }
    }
