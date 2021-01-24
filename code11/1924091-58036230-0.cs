    public class InternetExplorer
    {
    // List of URL objects
    public List<URL> URLs { get; set; }
    public IEnumerable<URL> GetHistory()
    {
        // Initiate main object
        UrlHistoryWrapperClass urlhistory = new UrlHistoryWrapperClass();
        // Enumerate URLs in History
        UrlHistoryWrapperClass.STATURLEnumerator enumerator =
        urlhistory.GetEnumerator();
        // Iterate through the enumeration
        while (enumerator.MoveNext())
        {
            // Obtain URL and Title
            string url = enumerator.Current.URL.Replace('\'', ' ');
            // In the title, eliminate single quotes to avoid confusion
            string title = string.IsNullOrEmpty(enumerator.Current.Title)
            ? enumerator.Current.Title.Replace('\'', ' ') : "";
            // Create new entry
            URL U = new URL(url, title, "Internet Explorer");
            // Add entry to list
            URLs.Add(U);
        }
        // Optional
        enumerator.Reset();
        // Clear URL History
        urlhistory.ClearHistory();
        return URLs;
    }
