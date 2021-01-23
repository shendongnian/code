    public class MyData : IHttpHandler
    {
        public void ProcessRequest (HttpContext context)
        {   
    	
    		context.Response.ContentType = "text/plain";
    		context.Response.AddHeader("Content-Disposition", "filename=\"myData.txt\"");	
    			
    		using(var db = new DbDataContext) {
    			
    			var data = db.Table.ToList(); //add Where(), OrderBy(), etc to filter and sort your data
    			
    			string fieldDelimeter = "\t";
    			foreach(var item in data) {
    			
    				context.Response.Write(item.Field1 + fieldDelimeter);
    				context.Response.Write(item.Field2 + fieldDelimeter);
    				context.Response.Write(item.Field3 + fieldDelimeter);
    				context.Response.Write(item.Field3 + fieldDelimeter);
    				context.Response.Write(Environment.NewLine);
    			}
    		}
    	}
    }
