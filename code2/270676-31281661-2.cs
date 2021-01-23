    <%@ Page Language="C#" %>
    <%@ Import Namespace="System.Globalization" %>
    <%@ Import Namespace="System.Web.Script.Serialization" %>
    <%@ Import Namespace="System.Collections.Generic" %>
    <%
    string s = "{ \"user\" : {    \"id\" : 12345,    \"screen_name\" : \"twitpicuser\"}}";
    var serializer = new JavaScriptSerializer();
    Dictionary<string, object> result = (serializer.DeserializeObject(s) as Dictionary<string, object>);
    Dictionary<string, object> usr = (result["user"] as Dictionary<string, object>);
    var UserId = usr["id"];
     %>
     <%= UserId %>
