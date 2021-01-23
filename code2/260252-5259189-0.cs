        public static void ModifyWhere<T>(this List<T> list, Func<T, bool> condition, Func<T, T> act)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (condition(list[i]))
                    list[i] = act(list[i]);
            }
        }
    }
