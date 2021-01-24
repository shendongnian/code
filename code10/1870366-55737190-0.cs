    using System;
    using System.Collections.Generic;
    using System.Text;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Markup;
    
    namespace MyProjectNamespace
    {
        [ContentProperty(Name = nameof(HtmlContent))]
        public class WebAssemblyHtmlControl : Control
        {
            public WebAssemblyHtmlControl()
             : base(htmlTag: "div") // the root HTML tag of your content
            {
            }
    
            private string _html;
    
            public string HtmlContent
            {
                get => _html;
                set
                {
                    base.SetHtmlContent(value); // this is a protected method on Wasm target   
                    _html = value;
                }
            }
        }
    }
