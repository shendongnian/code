    using Prism.DryIoc;
    //Private and Public variables
    public partial class App
    {
        /// <summary>
        /// Actual Dry Ioc Container which can be called and used for manual registering and resolving dependencies.
        /// </summary>
        public static IContainer AppContainer { get; set; }
    }
