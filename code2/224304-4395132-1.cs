    bool isValid = !source.Where(char.IsLetter)
                         .Where((ch, index) =>
                             {
                                var temp = source.Take(index+1);
                                return temp.Count(c => c == char.ToUpper(c)) 
                                       < temp.Count(c => c == char.ToLower(c));
                             })
                         .Any();
