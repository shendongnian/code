     public static class ListExtension
    {
        public static List<T> SortList<T>(this List<T> data, string sortDirection, string sortExpression)
        {
            try
            {
                switch (sortDirection)
                {
                    case "Ascending":
                        data = (from n in data
                                orderby GetDynamicSortProperty(n, sortExpression) ascending
                                select n).ToList();
                        break;
                    case "Descending":
                        data = (from n in data
                                orderby GetDynamicSortProperty(n, sortExpression) descending
                                select n).ToList();
                        break;
                    default:
                        data = null; //NUL IF IS NO OPTION FOUND (Ascending or Descending)
                        break;
                }
                return data;
            } catch(Exception ex){
                throw new Exception("Unable to sort data", ex);
            }
        }
        private static object GetDynamicSortProperty(object item, string propName)
        {
            //Use reflection to get order type          
            return item.GetType().GetProperty(propName).GetValue(item, null);
        }
    }
