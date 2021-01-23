    public class NumberSuffixParser
    {
        private static readonly Regex rxPattern = new Regex( @"^(?<number>\d+(\.\d+)?)(?<suffix>\p{L}+)$" , RegexOptions.IgnoreCase|RegexOptions.ExplicitCapture ) ;
        
        public void Parse( string value , out decimal number , out string suffix )
        {
            if ( value == null ) throw new ArgumentNullException("value") ;
            Match match = rxPattern.Match( value ) ;
            if ( ! match.Success ) throw new ArgumentOutOfRangeException("value") ;
            number = decimal.Parse( match.Groups["number"].Value ) ;
            suffix =                match.Groups["suffix"].Value   ;
            return ;
        }
        
        public decimal ParseNumber( string value )
        {
            decimal number ;
            string  suffix ;
            Parse( value , out number , out suffix ) ;
            return number ;
        }
        
        public string ParseSuffix( string value )
        {
            decimal number ;
            string  suffix ;
            Parse( value , out number , out suffix ) ;
            return suffix ;
        }
        
    }
