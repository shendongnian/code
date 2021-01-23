        public static int CustomIndexOf(this string source, char toFind, int position)
        {
            int index = -1;
            for (int i = 0; i < position; i++)
            {
                index = source.IndexOf(toFind, index + 1);
                if (index == -1)
                    break;
            }
            return index;
        }
