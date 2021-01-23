        using System; 
    using System.DHTML; 
    namespace Framework 
    { 
        // plugin options using a [Record] structure 
        [Record] 
        public sealed class SimplePluginOptions 
        { 
            public string cssproperty; 
            public string cssvalue; 
        } 
        // this static class will extend jQuery with 
        // an instance of our class using the jQuery.fn.extend function 
        // following common jQuery plugin practices 
        // (probably, it could be moved to the Simple class, will try it 
    later) 
        public static class SimplePlugin 
        { 
            public static void Initialize() 
            { 
                jQuery.fn.extend( new Simple() ); 
            } 
        } 
        // this is the class, that contains the definition of our 
    extension 
        // each public method will become another method on jQuery 
        public class Simple : jQuery 
        { 
            // this will hold the default options 
            private SimplePluginOptions _options; 
            // this will create the default options 
            public Simple() 
            { 
                _options  = new SimplePluginOptions(); 
                _options.cssproperty = "border"; 
                _options.cssvalue = "1px solid red"; 
            } 
            // this method will be available for all jQuery objects 
            public jQuery DoSimple(SimplePluginOptions options) 
            { 
                // extending the default options with custom options 
                _options = (SimplePluginOptions)jQuery.extend(_options, 
    options); 
                // for each DOMElmement, we'll apply the css property 
                // as jQuery selector can return multiple objects 
                return this.each((EachCallback)delegate(int index, 
    DOMElement elm) 
                { 
                    jqProxy.jQuery(elm).css(_options.cssproperty, 
    _options.cssvalue); 
                }); 
            } 
        } 
        // just to test our little extension, we write a static class with 
    a static constructor 
        // this will translate to only the code in the InitAll method 
    being executed 
        [IgnoreNamespace] 
        public static class InitAll 
        { 
            static InitAll() 
            { 
                SimplePlugin.Initialize(); // intialize our plugin, to add 
    extent jQuery 
                // when document ready, change color of border of all 
    div's 
                // using our Simple extension 
                jqProxy.jQuery(typeof(Document)).ready((Callback)delegate 
    () 
                { 
                    // just wait, so we can see the changes 
                    Script.Alert("wait"); 
                    // the result of jQuery selection has to be cast to 
    our Simple class 
                    // otherwise the DoSimple method will not be visible 
    (only necessary 
                    // when calling from c#, in javascript you could just 
    write 
                    // $("div").DoSimple(null); 
                    Simple test = (Simple)jqProxy.jQuery("div"); 
                    // we pass null, to see if the default options are 
    being used 
                    test.DoSimple(null); 
                }); 
            } 
        } 
    } 
