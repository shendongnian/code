    public class MediaModelBinder : BaseModelBinder, IModelBinder 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaModelBinder"/> class.
        /// </summary>
        public MediaModelBinder() : base(DependencyInjection.Resolve<IUserAuthorization>()) { }
        /// <summary>
        /// Binds the model to a value by using the specified controller context and binding context.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="bindingContext">The binding context.</param>
        /// <returns>The bound value.</returns>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var mediaRepository = DependencyInjection.Resolve<IMediaRepository>();
            User user = GetUser(controllerContext);
            int mediaId = Convert.ToInt32(controllerContext.RouteData.Values["id"]);
            Media media = mediaRepository.RetrieveByPrimaryKeyAndUserId(mediaId, user.Id);
            return media;
        }
    }
