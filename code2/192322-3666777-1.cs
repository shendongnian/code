          <div>
                <input type="text" id="txtSearchText" value=""/>
                <input type="button" id="btnSearch" value="Search"/>
          </div>
                <script type="text/javascript">
                   $("#btnSearch").click(function(){
                      var formPost={ SearchText : $("#txtSearchText").val()}; 
    //The above SearchText parameter name should be same as property name in the Model class.
                      $.post("/SearchController/Search",formPost,function(data){
                      if(data)
                      {
                         //Here based on your development methodology, either build a table by    
                          //appending a row for each result Or bind to a grid, if you are using  
                          //any third party control
                      }
                      });
                   });
                
                </script>
    Controller Code :
    public class SearchController
    {
        public ActionMethod Search(SearchModel searchCriteria)
        {
               SearchResultModel result= //Get the search results from database
               return new JsonResult{Data=result};
        }
    }
    
    Model class:
    public class SearchModel
    {
    public string SearchText{get;set;};
    }
