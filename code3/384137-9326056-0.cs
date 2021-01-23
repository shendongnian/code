    using System;
    using System.Data;
    using System.Web;
    using System.Linq;
    using System.Collections;
    using Newtonsoft.Json;
    public class Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "application/json";
        string quer = context.Request["query"];
        DataTable _t = AMC.Core.Logic.Root.Storage.ExecuteQuery("SELECT [tag_name] FROM [tags] Where [tag_name] like '%' + @ke + '%'", new System.Data.SqlClient.SqlParameter("ke", quer));
        
        DataRow[] list = new DataRow[_t.Rows.Count];
        _t.Rows.CopyTo(list, 0);
        
        var wapper = new { 
            query = quer
            , suggestions = (from row in list select row["tag_name"].ToString()).ToArray()
            //, data = new[] { "LR", "LY", "LI", "LT" } 
        };
        context.Response.Write(JsonConvert.SerializeObject(wapper));            
    }
