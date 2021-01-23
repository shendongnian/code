    public static class Func
    {
        /// <summary>
        /// Finds a specific type of parent.
        /// </summary>
        /// <typeparam name="T">The type of parent to find.</typeparam>
        /// <param name="dep">The child object.</param>
        /// <returns></returns>
        public static T FindParent<T>(this object obj)
        {
            DependencyObject dep = obj as DependencyObject;
            while ((dep != null) && !(dep is T))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            return (dep != null) ? (T)Convert.ChangeType(dep, typeof(T)) : default(T);
        }
    }
