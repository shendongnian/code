        private static IEnumerable<object> StringToArray2(string input)
        {
            var characters = input.GetEnumerator();
            return InternalStringToArray2(characters);
        }
        private static IEnumerable<object> InternalStringToArray2(IEnumerator<char> characters)
        {
            StringBuilder valueBuilder = new StringBuilder();
            while (characters.MoveNext())
            {
                char current = characters.Current;
                switch (current)
                {
                    case '[':
                        yield return InternalStringToArray2(characters);
                        break;
                    case ']':
                        yield return valueBuilder.ToString();
                        valueBuilder.Clear();
                        yield break;
                    case ',':
                        yield return valueBuilder.ToString();
                        valueBuilder.Clear();
                        break;
                    default:
                        valueBuilder.Append(current);
                        break;
                }
           
