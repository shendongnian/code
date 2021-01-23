    public class MyModel
    {
        public string ValidatedField {get; set;} // no HTML allowed here!
        
        [AllowHtml]
        public string NonValidatedField {get; set;} // user can enter HTML
    }
