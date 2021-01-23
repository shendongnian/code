        static object DeepCopyMine(object obj)
        {
            if (obj == null) return null;
            object newCopy;
            if (obj.GetType().IsArray)
            {
                var t = obj.GetType();
                var e = t.GetElementType();
                var r = t.GetArrayRank();
                Array a = (Array)obj;
                newCopy = Array.CreateInstance(e, a.Length);
                Array n = (Array)newCopy;
                for (int i=0; i<a.Length; i++)
                {
                    n.SetValue(DeepCopyMine(a.GetValue(i)), i);
                }
                return newCopy;
            }
            else
            {
                newCopy = Activator.CreateInstance(obj.GetType(), true);
            }
            foreach (var field in newCopy.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                if (!field.FieldType.IsPrimitive && field.FieldType != typeof(string))
                {
                    var fieldCopy = DeepCopyMine(field.GetValue(obj));
                    field.SetValue(newCopy, fieldCopy);
                }
                else
                {
                    field.SetValue(newCopy, field.GetValue(obj));
                }
            }
            return newCopy;
        }
