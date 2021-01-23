        string SomeProperty
        {
            get
            {
                return GetDesignModeValue(() => this.SomeProperty);
            }
        }
        string GetDesignModeValue<T>(Expression<Func<T>> propertyExpression)
        {
            var propName = (propertyExpression.Body as MemberExpression).Member.Name;
            var value = string.Format(
                "<{0}>"
                , propName);
            return value;
        }
