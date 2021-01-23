    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Xaml;
    
    namespace test
    {
        public class Language { }
    
        public class Country { public IEnumerable<Language> Languages { get; set; } }
    
        public class myClass
        {
            Collection<Language> _l = new Collection<Language>();
            public Collection<Language> Languages { get { return _l; } }
    
            Collection<Country> _c = new Collection<Country>();
            public Collection<Country> Countries { get { return _c; } }
    
            static void Main()
            {
                var xxr = new XamlXmlReader(new StreamReader("XMLFile1.xml"));
                var xow = new XamlObjectWriter(new XamlSchemaContext());
                XamlServices.Transform(xxr, xow);
                myClass mc = (myClass)xow.Result;
            }
        };
    }
