    using HtmlToPdf.Models;
    
    namespace HtmlToPdf.Console
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var model = new HtmlToPdfModel();
                model.HTML = "<h3>Hello world!</h3>";
                model.CSS = "h3{color:#f00;}";
    
                HtmlToPdf.Convert(model);
            }
        }
    }
HtmlToPdfModel.cs
