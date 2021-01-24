    public static class ImplementingFactory {
        public static Type ExtractorType(dynamic anObject) {
            Type oType = anObject.GetType();
            var iType = typeof(IExtractor<>).MakeGenericType(oType);
            var ans = iType.ImplementingTypes().FirstOrDefault();
            if (ans == null)
                throw new Exception($"Unable to find IExtractor<{oType.Name}>");
            else
                return ans;
        }
    }
