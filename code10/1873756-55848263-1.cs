    public static bool CheckDuplicate<T>(IEnumerable<T> list, object obj, string param1, string param2)
        {
            return list.Any(item =>
            item.GetPropValue(param1).Equals(obj.GetPropValue(param1)) &&
            item.GetPropValue(param2).Equals(obj.GetPropValue(param2))
            );
        }
