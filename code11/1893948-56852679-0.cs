    public class ApplicationDescription : IApplicationModelConvention
    {
        public ApplicationDescription()
        {                      
        }
        public void Apply(ApplicationModel application)
        {
            var ctr = application.Controllers.Where((model) => {
                return model.ControllerType.IsEquivalentTo(typeof(IgnoredController));
            });
            if (ctr.Count() > 0)
            {
                foreach (var controller in ctr.ToList())
                {
                    application.Controllers.Remove(controller);
                }
            }            
        }
    }
