    public class TestSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty sFooProperty = new ConfigurationProperty("Foo",
                                                                                              typeof(Foo),
                                                                                              null,
                                                                                              new FooTypeConverter(),
                                                                                              null,
                                                                                              ConfigurationPropertyOptions.None);
        public static readonly ConfigurationPropertyCollection sProperties = new ConfigurationPropertyCollection();
        static TestSection()
        {
            sProperties.Add(sFooProperty);
        }
        public Foo Foo
        {
            get { return (Foo)this[sFooProperty]; }
            set { this[sFooProperty] = value; }
        }
        protected override ConfigurationPropertyCollection Properties
        {
            get { return sProperties; }
        }
    }
