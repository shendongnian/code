     public static class MyExtensions
    {
        public static string ErrorMessage(this IList<String> strList)
        {
            string retMessage = null;
            for (int i = 0; i < strList.Count; i++)
            {
                retMessage += strList[i].ToString() + Environment.NewLine;
            }
            return retMessage;
        }
    }
