    public class RestrictCharRegExprAttribute: RegularExpressionAttribute
    {
        public RestrictCharRegExpressAttribute(string propRegex): base( GetRegex(propRegex)
        {
             this.Message = ...; // localized message
        }
        private string Message { get; }
        public override string FormatErrorMessage(string propertyName)
        {
            return this.Message; 
        }
    }
