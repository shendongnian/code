    public class AddAuthorizeFilters : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            controller.Filters.Add(new AuthorizeFilter("authwithsomepolicy"));            
        }
    }
