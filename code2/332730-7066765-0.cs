        public static Expression<Func<T, bool>> BuildStringMatch<T>(string searchFor) where T : IHasName
        {
            return b =>
                  string.IsNullOrEmpty(searchFor) ||
                  (b.Name != null &&
                    (b.Name.Trim().ToLower().StartsWith(searchFor.Trim().ToLower()) ||
                     b.Name.Contains(" " + searchFor)));
        }
