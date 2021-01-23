    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
        public class IntegrationTestAttribute : TestCategoryBaseAttribute
        {
            public IList<string> categories;
    
            public IntegrationTestAttribute()
            {
                this.categories = new List<String> { "Integration" };
            }
    
            public override IList<string> TestCategories
            {
                get
                {
                    return this.categories;
                }
            }
        }
