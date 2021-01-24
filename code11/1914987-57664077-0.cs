    public class Base64Utility
    {
        List<char> characterMap = new List<char>()
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            '+', '/'
        };
        public string Base64Encode(string source)
        {
            string result = string.Empty;
            int octetsMissing = 0;
            string byteString = string.Empty;
            byte[] bytes = new byte[source.Length];
            int[] base10Integers = new int[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                byte b = Convert.ToByte(source[i]);
                bytes[i] = (b);
                base10Integers[i] = Convert.ToInt32(bytes[i].ToString(), 10);
                byteString += Convert.ToString(bytes[i], 2).PadLeft(8, '0');
            }
            for (int byteIndex = 0; byteIndex < byteString.Length;)
            {
                int span = byteString.Length - byteIndex >= 6
                    ? 6
                    : byteString.Length - byteIndex;
                string subString = byteString.Substring(byteIndex, span);
                if (subString.Length < 6)
                {
                    octetsMissing = (6 - subString.Length) / 2;
                    for (int i = subString.Length; i < 6; i++)
                    {
                        subString += '0';
                    }
                }
                int index = Convert.ToInt32(subString, 2);
                result += characterMap[index];
                byteIndex += span;
            }
            for (int i = 0; i < octetsMissing; i++)
            {
                result += '=';
            }
            return result;
        }
        public string Base64Decode(string source)
        {
            string result = string.Empty;
            int[] mappedSource = new int[source.Length];
            string[] mappedSourceAsBinary = new string[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                if(source[i] != '=')
                {
                    mappedSource[i] = characterMap.IndexOf(source[i]);
                    mappedSourceAsBinary[i] = Convert.ToString(mappedSource[i], 2);
                }
                if(mappedSourceAsBinary[i] != null)
                {
                    if(mappedSourceAsBinary[i].Length < 6)
                    {
                        for(int j = mappedSourceAsBinary[i].Length; j < 6; j++)
                        {
                            mappedSourceAsBinary[i] = '0' + mappedSourceAsBinary[i];
                        }
                    }
                }
            }
            string temp = string.Empty;
            for(int i = 0; i < mappedSourceAsBinary.Length; i++)
            {
                temp += mappedSourceAsBinary[i];
            }
            string[] t = new string[temp.Length / 8];
            for (int i = 0; i < t.Length; i++)
            {
                t[i] = temp.Substring(8*i, 8);
                int res = Convert.ToInt32(t[i], 2);
                char resAscii = Encoding.ASCII.GetString(new byte[] { (byte)res })[0];
                result += resAscii;
            }
            return result;
        }
    }
    }
