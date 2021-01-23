Global.asax
    using System;
    using System.ServiceModel.Activation;
    using System.Web;
    using System.Web.Routing;
    namespace MyNamespace
    {
        public class Global : HttpApplication
        {
            protected void Application_Start(object sender, EventArgs e)
            {
                RouteTable.Routes.Add(new ServiceRoute("myservice", new WebServiceHostFactory(), typeof(MyService)));
            }
        }
    }
Service.cs
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;
    namespace MyNamespace
    {
        [ServiceContract]
        [ServiceBehavior(MaxItemsInObjectGraph = int.MaxValue)]
        [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
        public class MyService
        {
            [OperationContract]
            [WebInvoke(UriTemplate = "addObject", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
            public void AddObject(MyObject myObject)
            {
                // ...
            }
            [OperationContract]
            [WebInvoke(UriTemplate = "updateObject", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
            public void UpdateObject(MyObject myObject)
            {
                // ...
            }
            [OperationContract]
            [WebInvoke(UriTemplate = "deleteObject", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
            public void DeleteObject(Guid myObjectId)
            {
                // ...
            }
        }
    }
