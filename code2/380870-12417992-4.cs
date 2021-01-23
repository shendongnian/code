    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Windows.Markup;
    using System.Xaml;
    
    namespace test
    {
        public class Language { }
    
        public class Country { public IEnumerable<Language> Languages { get; set; } }
    
        public class LanguageSelector : MarkupExtension
        {
            public LanguageSelector(String items) { this.items = items; }
            String items;
    
            public override Object ProvideValue(IServiceProvider ctx)
            {
                var xnr = ctx.GetService(typeof(IXamlNameResolver)) as IXamlNameResolver;
    
                var tmp = items.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(s_lang => new
                                {
                                    s_lang,
                                    lang = xnr.Resolve(s_lang) as Language
                                });
    
                var err = tmp.Where(a => a.lang == null).Select(a => a.s_lang);
                return err.Any() ? 
                        xnr.GetFixupToken(err) : 
                        tmp.Select(a => a.lang).ToList();
            }
        };
    
        public class myClass
        {
            Collection<Language> _l = new Collection<Language>();
            public Collection<Language> Languages { get { return _l; } }
    
            Collection<Country> _c = new Collection<Country>();
            public Collection<Country> Countries { get { return _c; } }
    
            // you must set the name of your assembly here ---v
            const string s_xaml = @"
    <myClass xmlns=""clr-namespace:test;assembly=ConsoleApplication2""
             xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
    
        <myClass.Countries> 
            <Country x:Name=""UK"" Languages=""{LanguageSelector 'English'}"" /> 
            <Country x:Name=""France"" Languages=""{LanguageSelector 'French'}"" /> 
            <Country x:Name=""Italy"" Languages=""{LanguageSelector 'Italian'}"" /> 
            <Country x:Name=""Switzerland"" Languages=""{LanguageSelector 'English, French, Italian'}"" /> 
        </myClass.Countries> 
    
        <myClass.Languages>
            <Language x:Name=""English"" /> 
            <Language x:Name=""French"" /> 
            <Language x:Name=""Italian"" /> 
        </myClass.Languages> 
    
    </myClass>
    ";
            static void Main(string[] args)
            {
                var xxr = new XamlXmlReader(new StringReader(s_xaml));
                var xow = new XamlObjectWriter(new XamlSchemaContext());
                XamlServices.Transform(xxr, xow);
                myClass mc = (myClass)xow.Result;	/// works with forward references in Xaml
            }
        };
    }
