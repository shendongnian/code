    public class CalendarTagHelper : TagHelper
    {
        private readonly LinkGenerator _linkGenerator;
        
        public CalendarTagHelper(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        } 
