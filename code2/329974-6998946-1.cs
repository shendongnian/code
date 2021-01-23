     public static  bool matchWholeWord(string test, string search)
            {
                var index = test.IndexOf(search);
                if (index == -1)
                    return false;
    
                var after = index + search.Length;
                if (after == test.Length)
                    return true;
    
                return !char.IsLetterOrDigit(test[after]);
            }
