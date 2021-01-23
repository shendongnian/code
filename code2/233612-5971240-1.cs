    using System.Collections.Generic;
    using Microsoft.Phone.Controls;
    namespace BindingTest
    {
        public partial class MainPage : PhoneApplicationPage
        {
            // Constructor
            public MainPage()
            {
                InitializeComponent();
            }
        }
    
        public class SomeClass
        {
            private IList<string> _data = new List<string>() { "foo", "bar", "baz" };
            public IList<string> Items
            {
                get
                {
                    return _data;
                }
            }
    
            public string Foo { get { return "the moon"; } }
        }
    }
