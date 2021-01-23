    public class Division {
        public Company Company;  // The company to which the division belongs
        // ...
        private List<Feature> _divisionFeatures;  // private now
        public IEnumerable<Feature> DivisionFeatures {
            get {
                // Take all the features for the divison...
                return _divisionFeatures.Concat(
                    // ... and add all the company features except for those that
                    // have the same name as one of the division features.
                    Company.CompanyFeatures.Where(cf => !_divisionFeatures
                        .Any(df => df.Name == cf.Name))
                );
            }
        }
        // ...
    }
