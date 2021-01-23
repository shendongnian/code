    public class EnumUtility
        {
            public static string GetDisplayText<T>(T enumMember)
                where T : struct, IConvertible
            {
                if (!typeof(T).IsEnum)
                    throw new Exception("Requires enum only");
    
                var a = enumMember
                        .GetType()
                        .GetField(enumMember.ToString())
                        .GetCustomAttribute<DisplayTextAttribute>();
                return a == null ? enumMember.ToString() : a.Text;
            }
    
            public static Dictionary<int, string> ParseToDictionary<T>()
                where T : struct, IConvertible
            {
                if (!typeof(T).IsEnum)
                    throw new Exception("Requires enum only");
    
                Dictionary<int, string> dict = new Dictionary<int, string>();
                T _enum = default(T);
                foreach(var f in _enum.GetType().GetFields())
                {
                   if(f.GetCustomAttribute<DisplayTextAttribute>() is DisplayTextAttribute i)
                        dict.Add((int)f.GetValue(_enum), i == null ? f.ToString() : i.Text);
                }
                return dict;
            }
    
            public static List<(int Value, string DisplayText)> ParseToTupleList<T>()
                where T : struct, IConvertible
            {
                if (!typeof(T).IsEnum)
                    throw new Exception("Requires enum only");
    
                List<(int, string)> tupleList = new List<(int, string)>();
                T _enum = default(T);
                foreach (var f in _enum.GetType().GetFields())
                {
                    if (f.GetCustomAttribute<DisplayTextAttribute>() is DisplayTextAttribute i)
                        tupleList.Add(((int)f.GetValue(_enum), i == null ? f.ToString() : i.Text));
                }
                return tupleList;
            }
        }
