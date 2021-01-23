    bool isValid = source.Where(char.IsLetter)
                         .Where((ch, index) =>
                             {
                                var temp = source.Take(index);
                                return temp.Count(c => c == char.ToUpper(c)) 
                                       < temp.Count(c => c == char.ToLower(c));
                             })
                         .Any();
