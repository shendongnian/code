    public partial class ShortURL : IDataErrorInfo
    {
        private Dictionary<string, string> errors = new Dictionary<string, string>();
        
        partial void OnUrlChanging(string url)
        {
            if (!Regex.IsMatch(url, @"(^((http|ftp|https):\/\/|www\.)[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)"))
                errors.Add("Url", "Not a valid URL.");
        }
        public string Error
        {
            get { return string.Empty; } //I never use this so I just return empty.
        }
        public string this[string columnName]
        {
            get
            {
                if (errors.ContainsKey(columnName))
                    return errors[columnName];
                return string.Empty; //Return empty if no error in dictionary.
            }
        }
    }
