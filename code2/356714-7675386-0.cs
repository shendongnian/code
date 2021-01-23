    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Script.Serialization;
    const string json = @"{   ""error"" : ""0"", 
                                ""result"" :
                                {
                                   ""1256"" : {
                                      ""data"" : ""type any data"", 
                                      ""size"" : ""123456""
                                   },
                                   ""1674"" : {
                                      ""data"" : ""type any data"", 
                                      ""size"" : ""654321""
                                   },
                                   ""1845"" : {
                                      ""data"" : ""type any data"", 
                                      ""size"" : ""432516""
                                   },
                                    ""1956"" : {
                                      ""data"" : ""type any data"", 
                                      ""size"" : ""666666""
                                   }
                                }
                                }";
    JavaScriptSerializer j = new JavaScriptSerializer();
    var x = (Dictionary<string, object>)j.DeserializeObject(json);
    Foo foo = new Foo();
    foo.error = x["error"].ToString();
   
    foreach (KeyValuePair<string, object> item in (Dictionary<string, object>)x["result"])
    {
        SubResult result = new SubResult();
        ListLink listLink = new ListLink();
        var results = (Dictionary<string, object>)item.Value;
        foreach (KeyValuePair<string, object> sub in results)
        {
            listLink.data = results.First().Value.ToString();
            listLink.size = results.Last().Value.ToString();
        }
        SubResult subResult = new SubResult { attributes = listLink };
        foo.results.Add(subResult);
    }
