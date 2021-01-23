    namespace NamespaceName
    {
    public static class CommonUtil
    {
        public static string ListToString(this IList list)
        {
            StringBuilder result = new StringBuilder("");
 
            if (list.Count > 0)
            {
                result.Append(list[0].ToString());
                for (int i = 1; i < list.Count; i++)
                    result.AppendFormat(", {0}", list[i].ToString());
            }
            return result.ToString();
        }
      }
    }
