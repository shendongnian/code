    public class MyRequestFilter : IResourceFilter
    {
        // ... fields and constructor 
        
        // a helper method that will replace the extra MyRequestFilters with NopeFilter at runtime
        private void  DistinctThisTypeFilters(IList<IFilterMetadata> filters){
            var nopeFilter = new NopeFilter() ;
            var count = filters.Count();
            var thisTypeFilterCount = filters.OfType<MyRequestFilter>().Count();  // the total number: filters of this type 
            if(thisTypeFilterCount > 1){
                var alreadyReplaced = 0;  // the number that we have replaced till now
                for(var i = count -1 ; i > 0 ; i--){    // replace in reverse order
                    var filter = filters[i];
                    if(filter.GetType()== typeof(MyRequestFilter))
                    {
                        if(alreadyReplaced < thisTypeFilterCount -1 ){
                            filters[i]= nopeFilter;
                            alreadyReplaced++;
                        }
                    }
                }
            }
        }
    
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            this.DistinctThisTypeFilters(context.Filters);  // add this line so that only the first one will take effect. 
            // do some checks here using _someValues
            ...
        }
    
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }
    ```
