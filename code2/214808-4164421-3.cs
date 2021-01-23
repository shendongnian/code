    using System.IO;
    using System.Web.Script.Serialization;
    public class JsonModelBinder : DefaultModelBinder {
            public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
                if(!IsJSONRequest(controllerContext)) {
                    return base.BindModel(controllerContext, bindingContext);
                }
    
                // Get the JSON data that's been posted
                var request = controllerContext.HttpContext.Request;
                //in some setups there is something that already reads the input stream if content type = 'application/json', so seek to the begining
                request.InputStream.Seek(0, SeekOrigin.Begin);
                var jsonStringData = new StreamReader(request.InputStream).ReadToEnd();
     
                // Use the built-in serializer to do the work for us
                return new JavaScriptSerializer()
                    .Deserialize(jsonStringData, bindingContext.ModelMetadata.ModelType);
    
                // -- REQUIRES .NET4
                // If you want to use the .NET4 version of this, change the target framework and uncomment the line below
                // and comment out the above return statement
                //return new JavaScriptSerializer().Deserialize(jsonStringData, bindingContext.ModelMetadata.ModelType);
            }
    
            private static bool IsJSONRequest(ControllerContext controllerContext) {
                var contentType = controllerContext.HttpContext.Request.ContentType;
                return contentType.Contains("application/json");
            }
        }
    public static class JavaScriptSerializerExt {
            public static object Deserialize(this JavaScriptSerializer serializer, string input, Type objType) {
                var deserializerMethod = serializer.GetType().GetMethod("Deserialize", BindingFlags.NonPublic | BindingFlags.Static);
    
                // internal static method to do the work for us
                //Deserialize(this, input, null, this.RecursionLimit);
    
                return deserializerMethod.Invoke(serializer,
                    new object[] { serializer, input, objType, serializer.RecursionLimit });
            }
        }
