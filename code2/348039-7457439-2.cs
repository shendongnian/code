    <%@ WebHandler Language="C#" Class="JsonDotnet" %>
    using System;
    using System.IO;
    using System.Web;
    using Newtonsoft.Json;
    
    public class JsonDotnet : IHttpHandler {
      public void ProcessRequest (HttpContext context) {
        string json = context.Server.MapPath(
          "~/app_data/json-test.txt"
        );
        UserInfo user = Newtonsoft.Json.JsonConvert
        .DeserializeObject<UserInfo>(
          File.ReadAllText(json)
        );
        context.Response.Write(user.id + "<br>");
        context.Response.Write(user.name + "<br>");
        context.Response.Write(user.work[0].employer.name + "<br>");
      }
      public bool IsReusable {
        get { return false; }
      }
      public class Employer  {
        public string name { get; set;}
      }
      public class Position {
        public string name { get; set;}
      }
      public class Work {
        public Employer employer { get; set;}
        public Position position { get; set;}
      }
      public class UserInfo {
        public string id { get; set;}
        public string name { get; set;}
        public Work[] work { get; set;}
      }
    }
