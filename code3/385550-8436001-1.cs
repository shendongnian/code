        static T[] ExtractArray(List<T> list)
        {
            //list.TrimExcess();
            var t = list.GetType();
            var items = t.GetField("_items", 
                BindingFlags.NonPublic | BindingFlags.Instance);
            return items.GetValue(list) as T[];
        }
