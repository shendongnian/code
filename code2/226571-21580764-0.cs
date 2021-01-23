        [System.Diagnostics.DebuggerHidden]
        public static Type GetIndexedType(this ICollection poICollection)
        {
            PropertyInfo oPropertyInfo = poICollection == null ? null : poICollection.GetType().GetProperty("Item");
            return oPropertyInfo == null ? null : oPropertyInfo.PropertyType;
        }
        [System.Diagnostics.DebuggerHidden]
        public static Type GetEnumeratedType(this ICollection poICollection)
        {
            PropertyInfo oPropertyInfo = poICollection == null ? null : poICollection.GetType().GetMethod("GetEnumerator").ReturnType.GetProperty("Current");
            return oPropertyInfo == null ? null : oPropertyInfo.PropertyType;
        }
