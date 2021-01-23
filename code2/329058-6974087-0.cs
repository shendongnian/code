    public string NoDups (string input) {
                string ret = "";
                foreach(char c in input.ToCharArray()) {
                        if(!ret.Contains(c)) {
                               ret += c;
                        }
                }
                return ret;
          }
