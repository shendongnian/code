    public class UniqueTitleAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(
           object value, ValidationContext validationContext)
        {
            var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
            var entity = context.Articles.SingleOrDefault(e => e.Title == value.ToString());
            if (entity != null)
            {
                return new ValidationResult(GetErrorMessage(value.ToString()));
            }
            return ValidationResult.Success;
        }
        public void AddValidation(ClientModelValidationContext context)
        {
            Type obj = typeof(Article);
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-uniquetitle", GetErrorMessage());
        }
        private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }
            attributes.Add(key, value);
            return true;
        }
        public string GetErrorMessage()
        {
            return $"The title is already in use.";
        }
        public string GetErrorMessage(string title)
        {
            return $"Title {title} is already in use.";
        }
    }
