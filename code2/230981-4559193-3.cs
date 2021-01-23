    public class AlbumModelBinder : IModelBinder
    {
        public object BindModel
        (ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            int albumId;
            var albumVar = bindingContext.ValueProvider.GetValue( "album" );
            if (albumVar != null)
            {
                albumId = int.Parse( albumVar.AttemptedValue );
            }
            else
            {
                albumId = int.Parse( bindingContext.ValueProvider.GetValue( "albumId" ).AttemptedValue );
            }
            return albumId;
        }
    }
