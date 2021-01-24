    public class DisplaySiteTextAttribute : DisplayAttribute
    {
        public DisplaySiteTextAttribute(string key)
        {
            Name = TextManager.GetValue(key);
        }
    }
