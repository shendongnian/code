    public string[] GetPeopleAutoComplete(string filter, int maxResults, string searchType, string searchOption)
        {
             var query = (from person in _context.People
                    where MatchesSearchCriteria(searchType, searchOption, filter)
                    select SelectAttribute(person,searchType,searchOption));
        
             if (RequiresDistinct(filter,searchType, searchOption))
                  query = query.Distinct();
        
             return query.Take(maxResults).ToArray();
        }
        
        private bool MatchesSearchCriteria(string searchType, string searchOption, string filter)
        { 
             //Implement some switching here...
        }
        
        private string SelectAttribute(Person person, string searchType, string searchOption)
        {
            //Implement some switching here to select the correct value from the person
        }
        
        private bool RequiresDistinct(string searchType, string searchOption)
        { 
            //Return true if you need to select distinct values for this type of search
        }
