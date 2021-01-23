    public class AlbumModelBinder : IModelBinder
    {
        public object BindModel
        (ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            int albumId = int.Parse( bindingContext.ValueProvider.GetValue( "album" ).AttemptedValue );
            return albumId;
        }
    }
