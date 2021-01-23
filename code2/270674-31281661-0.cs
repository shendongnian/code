    <%@ Page Language="C#" %>
    <%@ Import Namespace="System.Globalization" %>
    <%@ Import Namespace="System.Web.Script.Serialization" %>
    <%@ Import Namespace="System.Collections.Generic" %>
    <%
    
    string output = "error";
    string s = "{ \"id\" : 12345,    \"screen_name\" : \"twitpicuser\"}";
    var serializer = new JavaScriptSerializer();
    Dictionary<string, object> result = (serializer.DeserializeObject(s) as Dictionary<string, object>);
    
    var UserId = result["id"];
    
    
     %>
    
     <%=UserId %>
