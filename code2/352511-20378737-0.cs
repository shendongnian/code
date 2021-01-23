        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is System.Collections.ObjectModel.Collection<string>)
            {
                foreach (var c in (System.Collections.ObjectModel.Collection<string>)value)
                {
                    c = LocalizationResourcesManager.GetTranslatedText(c);
                }
            }
            return value;
        }
