	public static class TaskGetter
    {
        private static string _propertyName;
        private static Type _taskType;
        private static PropertyInfo _property;
        private static Func<Task> _getter;
        static TaskGetter()
        {
            _taskType = typeof(Task);
            _propertyName = "InternalCurrent";
            SetupGetter();
        }
        public static void SetPropertyName(string newName)
        {
            _propertyName = newName;
            SetupGetter();
        }
        public static Task CurrentTask
        {
            get
            {
                return _getter();
            }
        }
        private static void SetupGetter()
        {
            _getter = () => null;
            _property = _taskType.GetProperties(BindingFlags.Static | BindingFlags.NonPublic).Where(p => p.Name == _propertyName).FirstOrDefault();
            if (_property != null)
            {
                _getter = () =>
                {
                    var val = _property.GetValue(null);
                    return val == null ? null : (Task)val;
                };
            }
        }
    }
