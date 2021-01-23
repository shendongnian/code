    /// <summary>
    /// Class level summary documentation goes here.</summary>
    /// <remarks>
    /// Longer comments can be associated with a type or member through
    /// the remarks tag.</remarks>
    public class TestClass : TestInterface
    {
        /// <summary>
        /// Store for the name property.</summary>
        private string _name = null;
    
        /// <summary>
        /// The class constructor. </summary>
        public TestClass()
        {
            // TODO: Add Constructor Logic here.
        }
    
        /// <summary>
        /// Name property. </summary>
        /// <value>
        /// A value tag is used to describe the property value.</value>
        public string Name
        {
            get
            {
                if (_name == null)
                {
                    throw new System.Exception("Name is null");
                }
                return _name;
            }
        }
    
        /// <summary>
        /// Description for SomeMethod.</summary>
        /// <param name="s"> Parameter description for s goes here.</param>
        /// <seealso cref="System.String">
        /// You can use the cref attribute on any tag to reference a type or member 
        /// and the compiler will check that the reference exists. </seealso>
        public void SomeMethod(string s)
        {
        }
    }
