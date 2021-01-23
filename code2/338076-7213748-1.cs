    public static class Extensions
    {
        public static T GetChildByType<T>(this UIElement element, Func<T, bool> condition)
            where T : UIElement
        {
            List<T> results = new List<T>();
            GetChildrenByType<T>(element, condition, results);
            if (results.Count > 0)
                return results[0];
            else
                return null;
        }
        private static void GetChildrenByType<T>(UIElement element, Func<T, bool> condition, List<T> results)
            where T : UIElement
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                UIElement child = VisualTreeHelper.GetChild(element, i) as UIElement;
                if (child != null)
                {
                    T t = child as T;
                    if (t != null)
                    {
                        if (condition == null)
                            results.Add(t);
                        else if (condition(t))
                            results.Add(t);
                    }
                    GetChildrenByType<T>(child, condition, results);
                }
            }
        }
    }
