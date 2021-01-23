        //compatible C# and JAVA
        public static int GetNumber(string Text)
        {
            int val = 0;
            for(int i = 0; i < Text.Length; i++)
            {
                char c = Text[i];
                if (c >= '0' && c <= '9')
                {
                    val *= 10;
                    //(ASCII code reference)
                    val += c - 48;
                }
            }
            return val;
        }
