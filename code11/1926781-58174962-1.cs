public class PostDataModelBinder : IModelBinder
{
    public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
    {
        if (bindingContext.ModelType != typeof(PostDataModel))
        {
            return false;
        }
        try
        {
          // Get the content of the request, deserialize into your model object
          Task<string> bodyTask = actionContext.Request.Content.ReadAsStringAsync();
          PostDataModel vm = JsonConvert.DeserializeObject<PostDataModel>(bodyTask.Result);
  
          // Get an instance of your IService and get metadata
          var service = (IService)actionContext.ControllerContext.Configuration.DependencyResolver.GetService(typeof(IService));
          var metadata = service.GetMetadata();
          // this is how you would get the Metadata directly from your controller as long as it was accessible
          //var metadata = ((IMetadata)actionContext.ControllerContext.Controller).Metadata;
        
          // do stuff with metadata to validate your object however you wish
          vm.PopulateValidationErrors();
          // return true if you were able to deserialize this object, false if you couldn't 
          return vm != null;
        }
        catch {
          // do logging
          return false;
        }
    }
}
Use IModelBinder globally by adding it to the Register method of WebApiConfig
config.BindParameter(typeof(PostDataModel), new PostDataModelBinder());
