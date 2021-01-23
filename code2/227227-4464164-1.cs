    static string SplitAndInsert(string s, int afterEvery, char insertCharacter) {
            if (s.Length < afterEvery) {
                return s + insertCharacter;
            }
            else {
                return 
                    s.Substring(0, afterEvery) +
                    insertCharacter +
                    SplitAndInsert(
                        s.Substring(afterEvery, s.Length - afterEvery),
                        afterEvery,
                        insertCharacter
                    );
            }
        }
