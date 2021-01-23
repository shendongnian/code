        /// <summary>
        /// Converts the object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="parent">The parent.</param>
        /// <param name="child">The child.</param>
        public static void ConvertObject<T, U>(T parent, U child)
        {
            foreach (PropertyInfo property in parent.GetType().GetProperties())
            {
                if (property.CanWrite)
                {
                    property.SetValue(child, property.GetValue(parent));
                }
            }
        }
