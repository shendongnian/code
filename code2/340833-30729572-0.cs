    public static class StringUtils
    {
        #region Private members
    
        [ThreadStatic]
        private static StringBuilder m_ReplaceSB;
    
        private static StringBuilder GetReplaceSB(int capacity)
        {
            var result = m_ReplaceSB;
    
            if (null == result)
            {
                result = new StringBuilder(capacity);
                m_ReplaceSB = result;
            }
            else
            {
                result.Clear();
                result.EnsureCapacity(capacity);
            }
    
            return result;
        }
    
    
        public static string ReplaceAny(this string s, char replaceWith, params char[] chars)
        {
            if (null == chars)
                return s;
    
            if (null == s)
                return null;
    
            StringBuilder sb = null;
    
            for (int i = 0, count = s.Length; i < count; i++)
            {
                var temp = s[i];
                var replace = false;
    
                for (int j = 0, cc = chars.Length; j < cc; j++)
                    if (temp == chars[j])
                    {
                        if (null == sb)
                        {
                            sb = GetReplaceSB(count);
                            if (i > 0)
                                sb.Append(s, 0, i);
                        }
    
                        replace = true;
                        break;
                    }
    
                if (replace)
                    sb.Append(replaceWith);
                else
                    if (null != sb)
                        sb.Append(temp);
            }
    
            return null == sb ? s : sb.ToString();
        }
    }
