        [System.Diagnostics.DebuggerHidden]
        public static Type GetEnumeratedType(this System.Collections.IEnumerator poIEnumerator)
        {
            PropertyInfo oPropertyInfo = poIEnumerator == null ? null : poIEnumerator.GetType().GetProperty("Current");
            return oPropertyInfo == null ? null : oPropertyInfo.PropertyType;
        }
