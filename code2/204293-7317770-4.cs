        private static List<IAccessible> AccChildren(IAccessible accessible)
        {
            object[] res = GetAccessibleChildren(accessible);
            var list = new List<IAccessible>();
            if (res == null) return list;
            foreach (object obj in res)
            {
                IAccessible acc = obj as IAccessible;
                if (acc != null) list.Add(acc);
            }
            return list;
        }
