    using System.Collections.Generic;
    using System.IO;
    using System.Web.Mvc;
    using System.Web.Script.Serialization;
    
    namespace Controllers
    {
        public class DictionaryModelBinder : IModelBinder
        {
            public object BindModel(ControllerContext context, ModelBindingContext bindingContext)
            {
                context.HttpContext.Request.InputStream.Seek(0, SeekOrigin.Begin);
                using (TextReader reader = new StreamReader(context.HttpContext.Request.InputStream))
                {
                    string requestContent = reader.ReadToEnd();
                    var arguments = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(requestContent);
                    return arguments[bindingContext.ModelName];
                }
            }
        }
    }
    
    using Controllers;
    using Moq;
    using NUnit.Framework;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    
    namespace ControllersTest
    {
        [TestFixture]
        public class DictionaryModelBinderTest
        {
            private ControllerContext controllerContext;
    
            [Test]
            public void ReturnsDeserializedPrimitiveObjectsAndDictionaries()
            {
                string input =
    @"{
        arguments: {
            simple: 1,
            complex: { a: 2, b: 3 },
            arrayOfSimple: [{ a: 4, b: 5 }],
            arrayOfComplex: [{ a: 6, b: 7 }, { a: 8, b: 9 }]},
        otherArgument: 1
    }";
                SetUpRequestContent(input);
    
                var binder = new DictionaryModelBinder();
                var bindingContext = new ModelBindingContext();
                bindingContext.ModelName = "arguments";
    
                var model = (Dictionary<string, object>)binder.BindModel(controllerContext, bindingContext);
    
                Assert.IsFalse(model.ContainsKey("otherArgument"));
                Assert.AreEqual(1, model["simple"]);
                var complex = (Dictionary<string, object>)model["complex"];
                Assert.AreEqual(2, complex["a"]);
                Assert.AreEqual(3, complex["b"]);
                var arrayOfSimple = (ArrayList)model["arrayOfSimple"];
                Assert.AreEqual(4, ((Dictionary<string, object>)arrayOfSimple[0])["a"]);
                Assert.AreEqual(5, ((Dictionary<string, object>)arrayOfSimple[0])["b"]);
                var arrayOfComplex = (ArrayList)model["arrayOfComplex"];
                var complex1 = (Dictionary<string, object>)arrayOfComplex[0];
                var complex2 = (Dictionary<string, object>)arrayOfComplex[1];
                Assert.AreEqual(6, complex1["a"]);
                Assert.AreEqual(7, complex1["b"]);
                Assert.AreEqual(8, complex2["a"]);
                Assert.AreEqual(9, complex2["b"]);
            }
    
            private void SetUpRequestContent(string input)
            {
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(input));
                stream.Seek(0, SeekOrigin.End);
    
                var controllerContextStub = new Mock<ControllerContext>();
                var httpContext = new Mock<HttpContextBase>();
                httpContext.Setup(x => x.Request.InputStream).Returns(stream);
                controllerContextStub.Setup(x => x.HttpContext).Returns(httpContext.Object);
                this.controllerContext = controllerContextStub.Object;
            }
        }
    }
    
    using Controllers;
    using PortalApi.App_Start;
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;
    
    namespace PortalApi
    {
        public class MvcApplication : System.Web.HttpApplication
        {
            protected void Application_Start()
            {
                AreaRegistration.RegisterAllAreas();
    
                WebApiConfig.Register(GlobalConfiguration.Configuration);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                ModelBinders.Binders.Add(typeof(Dictionary<string, object>), new DictionaryModelBinder());
            }
        }
    }
