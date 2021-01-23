    I was having the similar issue and solved by understanding the Classes in asp.net C#
    
    I want to read following JSON string :
    
    [
        {
            "resultList": [
                {
                    "channelType": "",
                    "duration": "2:29:30",
                    "episodeno": 0,
                    "genre": "Drama",
                    "genreList": [
                        "Drama"
                    ],
                    "genres": [
                        {
                            "personName": "Drama"
                        }
                    ],
                    "id": 1204,
                    "language": "Hindi",
                    "name": "The Great Target",
                    "productId": 1204,
                    "productMasterId": 1203,
                    "productMasterName": "The Great Target",
                    "productName": "The Great Target",
                    "productTypeId": 1,
                    "productTypeName": "Movie",
                    "rating": 3,
                    "releaseyear": "2005",
                    "showGoodName": "Movies ",
                    "views": 8333
                },
                {
                    "channelType": "",
                    "duration": "2:30:30",
                    "episodeno": 0,
                    "genre": "Romance",
                    "genreList": [
                        "Romance"
                    ],
                    "genres": [
                        {
                            "personName": "Romance"
                        }
                    ],
                    "id": 1144,
                    "language": "Hindi",
                    "name": "Mere Sapnon Ki Rani",
                    "productId": 1144,
                    "productMasterId": 1143,
                    "productMasterName": "Mere Sapnon Ki Rani",
                    "productName": "Mere Sapnon Ki Rani",
                    "productTypeId": 1,
                    "productTypeName": "Movie",
                    "rating": 3,
                    "releaseyear": "1997",
                    "showGoodName": "Movies ",
                    "views": 6482
                },
                {
                    "channelType": "",
                    "duration": "2:34:07",
                    "episodeno": 0,
                    "genre": "Drama",
                    "genreList": [
                        "Drama"
                    ],
                    "genres": [
                        {
                            "personName": "Drama"
                        }
                    ],
                    "id": 1520,
                    "language": "Telugu",
                    "name": "Satyameva Jayathe",
                    "productId": 1520,
                    "productMasterId": 1519,
                    "productMasterName": "Satyameva Jayathe",
                    "productName": "Satyameva Jayathe",
                    "productTypeId": 1,
                    "productTypeName": "Movie",
                    "rating": 3,
                    "releaseyear": "2004",
                    "showGoodName": "Movies ",
                    "views": 9910
                }
            ],
            "resultSize": 1171,
            "pageIndex": "1"
        }
    ]
    
    -----------
    
    My asp.net c# code looks like following
    
    1. Class3.cs page created in APP_Code folder of Web application 
    
    using System;
    using System.Data;
    using System.Configuration;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using System.Collections;
    using System.Text;
    using System.IO;
    using System.Web.Script.Serialization;
    using System.Collections.Generic;
    
    /// <summary>
    /// Summary description for Class3
    /// </summary>
    public class Class3
    {
    
        public List<ListWrapper_Main> ResultList_Main { get; set; }
    
        public class ListWrapper_Main
        {
            public List<ListWrapper> ResultList { get; set; }
    
            public string resultSize { get; set; }
            public string pageIndex { get; set; }
        }
    
        public class ListWrapper
        {
            public string channelType { get; set; }
            public string duration { get; set; }
            public int episodeno { get; set; }
            public string genre { get; set; }
            public string[] genreList { get; set; }
            public List<genres_cls> genres { get; set; }
            public int id { get; set; }
            public string imageUrl { get; set; }
            //public string imageurl { get; set; }
            public string language { get; set; }
            public string name { get; set; }
            public int productId { get; set; }
            public int productMasterId { get; set; }
            public string productMasterName { get; set; }
            public string productName { get; set; }
            public int productTypeId { get; set; }
            public string productTypeName { get; set; }
            public decimal rating { get; set; }
            public string releaseYear { get; set; }
            //public string releaseyear { get; set; }
            public string showGoodName { get; set; }
            public string views { get; set; }
        }
        public class genres_cls
        {
            public string personName { get; set; }
        }
    
    }
    
    --------------
    
    2. Broweser page that reads the string/JSON string listed above and displays/Deserialize the JSON objects and displays the data
    
    JavaScriptSerializer ser = new JavaScriptSerializer();
            
    
            string final_sb = sb.ToString();
    
            List<Class3.ListWrapper_Main> movieInfos = ser.Deserialize<List<Class3.ListWrapper_Main>>(final_sb.ToString());
            
            foreach (var itemdetail in movieInfos)
            {
    
                foreach (var itemdetail2 in itemdetail.ResultList)
                {
                    Response.Write("channelType=" + itemdetail2.channelType + "<br/>");
                    Response.Write("duration=" + itemdetail2.duration + "<br/>");
                    Response.Write("episodeno=" + itemdetail2.episodeno + "<br/>");
                    Response.Write("genre=" + itemdetail2.genre + "<br/>");
    
                    string[] genreList_arr = itemdetail2.genreList;
                    for (int i = 0; i < genreList_arr.Length; i++)
                        Response.Write("genreList1=" + genreList_arr[i].ToString() + "<br>");
    
                    foreach (var genres1 in itemdetail2.genres)
                    {
                        Response.Write("genres1=" + genres1.personName + "<br>");
                    }
    
                    Response.Write("id=" + itemdetail2.id + "<br/>");
                    Response.Write("imageUrl=" + itemdetail2.imageUrl + "<br/>");
                    //Response.Write("imageurl=" + itemdetail2.imageurl + "<br/>");
                    Response.Write("language=" + itemdetail2.language + "<br/>");
                    Response.Write("name=" + itemdetail2.name + "<br/>");
                    Response.Write("productId=" + itemdetail2.productId + "<br/>");
                    Response.Write("productMasterId=" + itemdetail2.productMasterId + "<br/>");
                    Response.Write("productMasterName=" + itemdetail2.productMasterName + "<br/>");
                    Response.Write("productName=" + itemdetail2.productName + "<br/>");
                    Response.Write("productTypeId=" + itemdetail2.productTypeId + "<br/>");
                    Response.Write("productTypeName=" + itemdetail2.productTypeName + "<br/>");
                    Response.Write("rating=" + itemdetail2.rating + "<br/>");
                    Response.Write("releaseYear=" + itemdetail2.releaseYear + "<br/>");
                    //Response.Write("releaseyear=" + itemdetail2.releaseyear + "<br/>");
                    Response.Write("showGoodName=" + itemdetail2.showGoodName + "<br/>");
                    Response.Write("views=" + itemdetail2.views + "<br/><br>");
                    //Response.Write("resultSize" + itemdetail2.resultSize + "<br/>");
                    //  Response.Write("pageIndex" + itemdetail2.pageIndex + "<br/>");
          
    
                }
    
    
    
                Response.Write("resultSize=" + itemdetail.resultSize + "<br/><br>");
                Response.Write("pageIndex=" + itemdetail.pageIndex + "<br/><br>");
    
            }
    
    
    'sb' is the actual string, i.e. JSON string of data mentioned very first on top of this reply
    
    This is basically - web application asp.net c# code....
    
    N joy...
