    var search = GetSearch(searchType);
    search.PerformSearch(searchText);
    int count = (int)Selenium.GetXpathCount("//[@id='Results_Table']");
    search.DoSomething(count);
    ...
    public interface ISearch
    {
        void PerformSearch(string searchText);
        void DoSomething();
    }
    
    public class SearchBooks : ISearch
    {
        public void PerformSearch(string searchText)
        {
            Selenium.Type("//*[@id='SearchBooks_TextInput']", searchText);
            Selenium.Click("//*[@id='SearchBooks_SearchBtn']");
        }
        
        void DoSomething()
        {
            // do something
        }
    }
    
    public class SearchAuthors : ISearch
    {
        public void PerformSearch(string searchText)
        {
            Selenium.Type("//*[@id='SearchAuthors_TextInput']", searchText);
            Selenium.Click("//*[@id='SearchBooks_SearchBtn']");
        }
    
        void DoSomething()
        {
            // do something else
        }
    }
