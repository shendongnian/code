    private class Replacer
    {
        private bool inQuotes;
        public string Replace( Match m ){
            if( m.Value == "\"" ){
                inQuotes = ! inQuotes;
            }else if ( inQuotes && m.Value == "##abc##" ){
                return "##xyz##";
            }
            return m.Value;
        }
    }
    input = "<a href=\"function(##abc##);function(##abc##)\">";
    Console.WriteLine( Regex.Replace( input, "\"|(##abc##)", (new Replacer()).Replace ) );
