        public static void MultiReplace(this StringBuilder builder, char[] toReplace, char replacement)
        {
            HashSet<char> set = new HashSet<char>(toReplace);
            for (int i = 0; i < builder.Length; ++i)
            {
                var currentCharacter = builder[i];
                if (set.Contains(currentCharacter))
                {
                    builder[i] = replacement;
                }
            }
        }
