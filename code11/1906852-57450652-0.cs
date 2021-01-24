    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class UniqueHrefLangAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var contentArea = value as ContentArea;
            if (contentArea != null && contentArea.Items != null)
            {
                var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
                var blocks = contentLoader
                    .GetItems(contentArea.Items.Select(i => i.ContentLink), CultureInfo.InvariantCulture)
                    .OfType<HrefLangBlock>();
                var duplicateHrefLangs = blocks
                    .GroupBy(b => b.HrefLangName)
                    .Where(grp => grp.Count() > 1)
                    .Select(grp => grp.Key)
                    .ToList();
                if (duplicateHrefLangs.Any())
                {
                    var errorMessage = $"Languages in '{validationContext.DisplayName}' must be unique. Duplicates: {string.Join(", ", duplicateHrefLangs)}";
                    return new ValidationResult(errorMessage, new[] { validationContext.MemberName });
                }
            }
            return ValidationResult.Success;
        }
    }
