        public enum MyEnumSearchTypes
        {
            SearchBooks, SearchAuthors, SearchSomethingElse 
        }
        public void MyDoSomethingMethod(MyEnumSearchTypes searchType)
        {
            switch (searchType)
            {
                case "SearchBooks":
                    Selenium.Type("//*[@id='SearchBooks_TextInput']", searchText);
                    Selenium.Click("//*[@id='SearchBooks_SearchBtn']");
                break;
                case "SearchAuthors":
                    Selenium.Type("//*[@id='SearchAuthors_TextInput']", searchText);
                    Selenium.Click("//*[@id='SearchAuthors_SearchBtn']");
                break;
            }    
        
            if (searchType == MyEnumDefinedTypes.SearchBooks)
            {     
               do something
            }       
            
            else if (searchType == MyEnumDefinedTypes.SearchAuthors)
            {     
               do something else
            }            
        
            else
            {     
               do nothing
            }     
        }        
        
