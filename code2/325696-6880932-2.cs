    public class TestSplitDetailViewModel
    {
        public int Id { get; set; }
        [CanEdit]
        public string RestrictedProperty { get; set; }
    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class CanEditAttribute : Attribute
    {
    }
    public class CanEditAttributeBinder : DefaultModelBinder
    {
        private readonly ISecurityTasks _securityTask;
        private readonly ISecurityContext _securityContext;
        public CanEditAttributeBinder(ISecurityTasks securityTask, ISecurityContext securityContext)
        {
            this._securityTask = securityTask;
            this._securityContext = securityContext;
        }
        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor)
        {
            var canEditAttribute = propertyDescriptor.Attributes
              .OfType<CanEditAttribute>()
              .FirstOrDefault();
            if (canEditAttribute != null)
            {
                bool allowed = IsAllowed();
                if (allowed)
                {
                    propertyDescriptor.SetValue(bindingContext.Model, null);
                }
                else
                {
                    base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
                }
            }
            else
            {
                base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
            }
        }
        private bool IsAllowed()
        {
            return !this._securityTask.DoesUserHaveOperation(this._securityContext.User.Username, UserOperations.ReclassAllowed);
        }
    }
    public class TestModelSpec : Specification<CanEditAttributeBinder>
    {
        protected static HomeController controller;
        private static MockRepository mocks;
        protected static ISecurityTasks securityTasks;
        private static ISecurityContext securityContext;
        protected static ModelBindingContext bindingContext;
        Establish context = () =>
        {
            ServiceLocatorHelper.AddUserServiceWithTestUserContext();
            securityTasks = DependencyOf<ISecurityTasks>().AddToServiceLocator();
            securityContext = DependencyOf<ISecurityContext>().AddToServiceLocator();
            user = new User("CHUNKYBACON");
            securityContext.User = user;
            // When we restricted access on the client, 
            // Chunky submitted a FORM POST in which he HACKED a value 
            var formCollection = new NameValueCollection
                    { 
                        { "TestSplitDetailViewModel.Id", "2" }, 
                        { "TestSplitDetailViewModel.RestrictedProperty", "12" } // Given this is a hacked value
                    };
            var valueProvider = new NameValueCollectionValueProvider(formCollection, null);
            var modelMetadata = ModelMetadataProviders.Current.GetMetadataForType(null, typeof(TestSplitDetailViewModel));
            bindingContext = new ModelBindingContext
            {
                ModelName = "TestSplitDetailViewModel",
                ValueProvider = valueProvider,
                ModelMetadata = modelMetadata
            };
            controller = new HomeController(null, null, null, null, null);
            mocks = new MockRepository();
            MvcMockHelpers.SetFakeControllerContext(mocks, controller);
        };
        protected static User user;
        protected static TestSplitDetailViewModel incomingModel;
    }
    public class when_a_restricted_user_changes_a_restricted_property : TestModelSpec
    {
        private Establish context = () => securityTasks.Stub(st =>
                                   st.DoesUserHaveOperation(user.Username, UserOperations.ReclassAllowed)).Return(false);
        Because of = () => incomingModel = (TestSplitDetailViewModel)subject.BindModel(controller.ControllerContext, bindingContext);
        It should_null_that_value_out = () => incomingModel.RestrictedProperty.ShouldBeNull();
    }
    public class when_an_unrestricted_user_changes_a_restricted_property : TestModelSpec
    {
        private Establish context = () => securityTasks.Stub(st =>
                                   st.DoesUserHaveOperation(user.Username, UserOperations.ReclassAllowed)).Return(true);
        Because of = () => incomingModel = (TestSplitDetailViewModel)subject.BindModel(controller.ControllerContext, bindingContext);
        It should_permit_the_change = () => incomingModel.RestrictedProperty.ShouldEqual("12");
    }
