    namespace Test
    {
      public partial class StartViewController : UIViewController
      {
        // No need for this here, since your TableSource will be holding 
        // and providing your data
        //private List<String> countryNames;
        //private List<String> countryLanguages;
        public StartViewController() : base("StartViewController", null)
        {
            
            // Best Practice not to call async methods from a constructor
            // A constructor should be fast and return, after running all 
            // of its code, right away.
            //GetCountries();
        }
        
        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            // Get your data and then set your source
            var countries = await RefreshDataAsync();
            
            var countryNames = new List<string>();
            foreach (var c in countries)
            {
                countryNames.Add(c.name);
            }
            // since you awaited the above, countryNames is now populated
            // before you set up your TableSource. 
            CountriesTableView.Source = new StartViewController.TableSource(countryNames, this); 
            // On a side note, by passing and holding onto a reference to
            // this UIViewController, you are creating a circular reference
            // which will cause a memory leak. You should not need a reference
            // to this view controller from your TableSource.             
        }
        ...
      }
      ...
    }
