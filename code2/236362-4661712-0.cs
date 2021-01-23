    public class MinSelectedAttribute : ValidationAttribute
    {
        public int MinSelected { get; set; }
        public override bool IsValid(object value)
        {
            var instance = value as IList<CheckList>;
            if (instance != null)
            {
                // make sure that you have at least MinSelected
                // IsChecked values equal to true inside the IList<CheckList>
                // collection for the model to be valid
                return instance.Where(x => x.IsChecked).Count() >= MinSelected;
            }
            return base.IsValid(value);
        }
    }
