    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class ProtectedPropertyAttribute : ValidationAttribute
    {
        private static Dictionary<string, LinkedList<object>> savedValues;
        static ProtectedPropertyAttribute()
        {
            savedValues = (Dictionary<string, LinkedList<object>>)HttpContext.Current.Session["ProtectedAttributeData"];
            if (savedValues != null) 
                return;
            savedValues = new Dictionary<string, LinkedList<object>>();
            HttpContext.Current.Session.Add("ProtectedAttributeData", savedValues);
        }
        public static void LockObject(object obj)
        {
            Type type = obj.GetType();
            foreach (PropertyInfo property in type.GetProperties())
            {
                LockProperty(obj, property);
            }
        }
        public static void LockProperty(object obj, PropertyInfo property)
        {
            ProtectedPropertyAttribute protectedAttribute =
                (ProtectedPropertyAttribute)
                property.GetCustomAttributes(typeof (ProtectedPropertyAttribute), false).FirstOrDefault();
            if (protectedAttribute == null)
                return;
            if(protectedAttribute.Identifier == null)
                protectedAttribute.Identifier = property.Name;
            LinkedList<object> list;
            if (!savedValues.TryGetValue(protectedAttribute.Identifier, out list))
            {
                list = new LinkedList<object>();
                savedValues.Add(protectedAttribute.Identifier, list);
            }
            list.AddLast(property.GetValue(obj, null));
        }
        public string Identifier { get; set; }
        public ProtectedPropertyAttribute()
        {
        }
        public ProtectedPropertyAttribute(string errorMessage) : base(errorMessage)
        {
        }
        public ProtectedPropertyAttribute(Func<string> errorMessageAccessor) : base(errorMessageAccessor)
        {
        }
        protected override ValidationResult IsValid (object value, ValidationContext validationContext)
        {
            LinkedList<object> lockedValues;
            if (Identifier == null)
                Identifier = validationContext.DisplayName;
            if (!savedValues.TryGetValue(Identifier, out lockedValues))
                return new ValidationResult(FormatErrorMessage(validationContext.MemberName), new[] { validationContext.MemberName });
            bool found = false;
            LinkedListNode<object> node = lockedValues.First;
            while (node != null)
            {
                if(node.Value.Equals(value))
                {
                    found = true;
                    break;
                }
                node = node.Next;
            }
            if(!found)
                return new ValidationResult(FormatErrorMessage(validationContext.MemberName), new[] { validationContext.MemberName });
            return ValidationResult.Success;
        }
    }
