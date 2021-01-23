    IEnumerable<string> tokenize(string str) {
        var result = new List<string>();
        int pos = -1;
        int state = 0;
        int temp = -1;
        while( ++pos < str.Length ) {
            switch(state) {
                case 0:
                    if( str[pos] == "$" ) { state = 1; temp = pos; }
                    break;
                case 1:
                    if( str[pos] == "{" ) { state = 2; } else { state = 0; }
                    break;
                case 2:
                    if( str[pos] == "}" } {
                        state = 0;
                        result.Add( str.Substring(0, temp) );
                        result.Add( str.Substring(temp, pos) );
                        str = str.Substring(pos);
                        pos = -1;
                    }
                    break;
                }
        }
        if( str != "" ) {
            result.Add(str);
        }
        return result;
    }
