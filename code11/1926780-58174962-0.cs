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
  
          // Retrieve your metadata from your controller.  In order to know it is there, have your controller implement an interface with a Metadata property that is accessible.
          // Your code shows it as private, you'll need to loosen that up so the ModelBinder has access
          var metadata = ((IMetadata)actionContext.ControllerContext.Controller).Metadata;
        
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
