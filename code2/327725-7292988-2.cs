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
    
