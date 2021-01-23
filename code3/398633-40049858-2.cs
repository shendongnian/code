    public static class PublishedContentExtensions
    {
        public static T GetPropertyLangValue<T>(this IPublishedContent content, string fieldName)
        {
            var lang = CoreHelper.GetSessionLanguage();
            if (string.IsNullOrEmpty(lang))
                return content.GetPropertyValue<T>(fieldName);
            return content.GetPropertyValue<T>($"{fieldName}_{lang}");
        }
    }
