    class WordCount {
        const string Symbols = ",;.:-()\t!¡¿?\"[]{}&<>+-*/=#'";
    
        public static string normalize(string str)
        {
            var toret = new StringBuilder();
            for(int i = 0; i < str.Length; ++i) {
                if ( Symbols.IndexOf( str[ i ] ) > -1 ) {
                    toret.Append( ' ' );
                } else {
                    toret.Append( char.ToLower( str[ i ] ) );
                }
            }
            return toret.ToString();
        }
    
        private string word;
        public string Word {
            get { return this.word; }
            set { this.word = value; }
        }
    
        private string str;
        public string Str {
            get { return this.str; }
        }
        private string[] words = null;
        public string[] Words {
           if ( this.words == null ) {
               this.words = this.Str.split( ' ' );
           }
           return this.words;
        }
    
        public WordCount(string str, string w)
        {
             this.str = ' ' + normalize( str ) + ' ';
             this.word = w;
        }
        public int Times()
        {
            return this.Times( this.Word );
        }
    
        public int Times(string word)
        {
            int times = 0;
            word = ' ' + word + ' ';
            int wordLength = word.Length;
            int pos = this.Str.IndexOf( word );
            while( pos > -1 ) {
                ++times;
                pos = this.Str.IndexOf( pos + wordLength, word );
            }
            return times;
        }
        public double Percentage()
        {
            return this.Percentage( this.Word );
        }
        public double Percentage(string word)
        {
            return ( this.Times( word ) / this.Words.Length );
        }
    }
