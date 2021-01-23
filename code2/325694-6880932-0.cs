    // Given a viewmodel with a super important property.
    public class TestViewModel
    {
        public int Id { get; set; }
        [CanChange]
        public string RestrictedProperty { get; set; }
    }
    // Restrict access with this attribute
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class CanChangeAttribute : Attribute
    {
    }
    public class CanChangeAttributeBinder : DefaultModelBinder
    {
        private readonly ISecurityTasks _securityTask;
        private readonly ISecurityContext _securityContext;
        public CanChangeAttributeBinder(ISecurityTasks securityTask, ISecurityContext securityContext)
        {
            this._securityTask = securityTask;
            this._securityContext = securityContext;
        }
        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
        {
            var changeChangeAttribute = propertyDescriptor.Attributes
              .OfType<CanChangeAttribute>()
              .FirstOrDefault();
			  
            if (changeChangeAttribute != null)
            {
                if (! _securityTask.DoesUserHaveOperation(_securityContext.User.Username, UserOperations.ReclassAllowed))
                {
                    propertyDescriptor.SetValue(bindingContext.Model, null);
                }
            }
            else
            {
                base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
            }
        }
    }
    // Given a restricted user, when binding a model, it should null out the marked properties.
    public class when_binding_a_simple_testobject : Specification<CanChangeAttributeBinder>
    {
        Establish context = () =>
            {
                // .. MISCELLANEOUS WIRE-UPS
                
                var user = new User("CHUNKYBACON");
                // When we restricted access on the client, 
                // Chunky submitted a FORM POST in which he HACKED a value 
                var formCollection = new NameValueCollection
                    { 
                        { "TestViewModel.Id", "2" }, 
                        { "TestViewModel.RestrictedProperty", "12" } // Chunky (tsk, tsk)....This should've been empty
                    };
                var valueProvider = new NameValueCollectionValueProvider(formCollection, null);
                var modelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, typeof(TestViewModel));
                bindingContext = new ModelBindingContext
                    {
                        ModelName = "TestViewModel",
                        ValueProvider = valueProvider,
                        ModelMetadata = modelMetadata
                    };
                controller = new HomeController(null, null, null, null, null);
                mocks = new MockRepository();
                MvcMockHelpers.SetFakeControllerContext(mocks, controller);
            };
        // When we bind us up the model....
        Because of = () => hair = (TestViewModel)subject.BindModel(controller.ControllerContext, bindingContext);
        It should_null_that_value_right_outta_my_hair = () => hair.RestrictedProperty.ShouldBeNull();
        private static TestViewModel hair;
        private static ModelBindingContext bindingContext;
        private static HomeController controller;
        private static MockRepository mocks;
        private static ISecurityTasks securityTasks;
        private static ISecurityContext securityContext;
    }
