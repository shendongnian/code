using System.Reflection;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using QueryStringAlias.Attributes;
namespace QueryStringAlias.ModelBinders
{
    public class AliasModelBinder : IModelBinder
    {
        private bool TryAdd(PropertyInfo pi, NameValueCollection nvc, string key, ref object model)
        {
            if (nvc[key] != null)
            {
                try
                {
                    pi.SetValue(model, Convert.ChangeType(nvc[key], pi.PropertyType));
                    return true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Skipped: {pi.Name}\nReason: {e.Message}");
                }
            }
            return false;
        }
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            Type bt = bindingContext.ModelType;
            object model = Activator.CreateInstance(bt);
            string QueryBody = actionContext.Request.Content.ReadAsStringAsync().Result;
            NameValueCollection nvc = HttpUtility.ParseQueryString(QueryBody);
            foreach (PropertyInfo pi in bt.GetProperties())
            {
                if (TryAdd(pi, nvc, pi.Name, ref model))
                {
                    continue;
                };
                foreach (BindAliasAttribute cad in pi.GetCustomAttributes<BindAliasAttribute>())
                {
                    if (TryAdd(pi, nvc, cad.Alias, ref model))
                    {
                        break;
                    }
                }
            }
            bindingContext.Model = model;
            return true;
        }
    }
}
In order to ensure that this runs as part of a WebAPI call you must also add `config.BindParameter(typeof(TestModelType), new AliasModelBinder()); ` in the Regiser portion of your `WebApiConfig`.
If you are using this method, you also must remove `[FromBody]` from your method signature.
        [HttpPost]
        [Route("mytestendpoint")]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        public async Task<MyApiCallResult> Signup(TestModelType tmt) // note that [FromBody] does not appear in the signature
        {
            // code happens here
        }
Note that this work builds on the answer above, using the `QueryStringAlias` samples.
At the moment this would likely fail in the case where TestModelType had complex nested types.  Ideally there are a few other things:
- handle complex nested types robustly
- enable an attribute on the class to activate the IModelBuilder as opposed to in the registration
- enable the same IModelBuilder to work in both Controllers and ApiControllers
But for now I'm satisfied with this for my own needs.  Hopefully someone finds this piece useful.
