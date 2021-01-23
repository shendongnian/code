        [System.Diagnostics.DebuggerHidden]
        public static Type GetEnumeratedType(this System.Collections.IEnumerable poIEnumerable)
        {
            PropertyInfo oPropertyInfo = poIEnumerable == null ? null : poIEnumerable.GetType().GetMethod("GetEnumerator").ReturnType.GetProperty("Current");
            return oPropertyInfo == null ? null : oPropertyInfo.PropertyType;
        }
