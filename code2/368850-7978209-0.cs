        public static class NameSplitter
        {
            public static MemberName Split(string fullName)
            {
                ...
                MemberName splitName = new MemberName(titles, firstNames, lastNames);
                return splitName;
            }
        }
