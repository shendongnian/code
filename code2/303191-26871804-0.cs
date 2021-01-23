    public static bool IsBase64String(string s)
        {
            s = s.Trim();
            int mod4 = s.Length % 4;
            if(mod4!=0){
                return false;
            }
            int i=0;
            bool checkPadding = false;
            int paddingCount = 1;//only applies when the first is encountered.
            for(i=0;i<s.Length;i++){
                char c = s[i];
                if (checkPadding)
                {
                    if (c != '=')
                    {
                        return false;
                    }
                    paddingCount++;
                    if (paddingCount > 3)
                    {
                        return false;
                    }
                    continue;
                }
                if(c>='A' && c<='z' || c>='0' && c<='9'){
                    continue;
                }
                switch(c){ 
                  case '+':
                  case '/':
                     continue;
                  case '=': 
                     checkPadding = true;
                     continue;
                }
                return false;
            }
            //if here
            //, length was correct
            //, there were no invalid characters
            //, padding was correct
            return true;
        }
