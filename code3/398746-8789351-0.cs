    public static string GetWord(string str,int index) {
                var vettWord = str.Split(' ');
                int position=0;
                foreach(var item in vettWord){
                    if ( index<= position+item.Length)
                    {
                        return item;
                    }
                   position += item.Length+1; // +1 to consider the white space
                }
                return string.Empty;
            }
