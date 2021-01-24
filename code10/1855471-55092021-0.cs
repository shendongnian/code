    //using System.Web.Http.ModelBinding;
    public class LegacyBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            //reading request data
            NameValueCollection formData = actionContext.ControllerContext.Request.Content.ReadAsFormDataAsync().GetAwaiter().GetResult();
            var model = new MyServiceRequest
            {
                Params = new List<string>()
            };
            model.Count = formData["count"];
            foreach (string name in formData)
            {
                //simple check, "param1" "paramRandomsring" will pass
                //if (name.StartsWith("param", StringComparison.InvariantCultureIgnoreCase))
                //more complex check ensures "param{number}" template
                if (Regex.IsMatch(name, @"^param\d+$", RegexOptions.IgnoreCase))
                {
                    model.Params.Add(formData[name]);
                }
            }
            bindingContext.Model = model;
            return true;
        }
    }
