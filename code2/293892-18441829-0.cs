    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Services;
    using FatSecretSharp.Services;
    using FatSecretSharp.Services.Requests;
    using System.Web.Script.Services;
    using System.Web.Script.Serialization;
    
    namespace WebService1
    {
        /// <summary>
        /// Summary description for Service1
        /// </summary>
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
        // [System.Web.Script.Services.ScriptService]
        public class Service1 : System.Web.Services.WebService
        {
            private static string consumerKey = string.Empty;
            private static string consumerSecret = string.Empty;
    
            private static FoodSearch foodSearch;
            
    
            public Service1()
            {
    
                //Uncomment the following line if using designed components 
                //InitializeComponent(); 
            }
    
            [WebMethod]
            [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
            public string SearchFood(string searchExpression)
            {
                try
                {
                    consumerKey = "your consumer Key";
    
                    consumerSecret = "your consumer Secret ";
    
                    var searchTerm = searchExpression;
    
                    foodSearch = new FoodSearch(consumerKey, consumerSecret);
    
                    var response = foodSearch.GetResponseSynchronously(new FoodSearchRequest()
                                        {
                                            SearchExpression = searchTerm,
                                            
                                            MaxResults = 50,
                                            PageNumber = 0
                                        });
    
                   
    
                    if (response != null && response.HasResults)
                    {
                        
                        return new JavaScriptSerializer().Serialize(response);
                    }
                    else
                    {
    
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
    
    
            }
    
               }
    }
