    public static bool IsResizable(this Stream stream)
        {
            bool result;
            long oldLength = stream.Length;
            try
            {
                stream.SetLength(oldLength + 1);
                result = true;
            }
            catch (NotSupportedException)
            {
                result = false;
            }
            if (result)
            {
                stream.SetLength(oldLength);
            }
            return result;
        }
