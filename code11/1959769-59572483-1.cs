    public class CustomListView : ListView
    {
        public static readonly BindableProperty IsNestedScrollProperty = BindableProperty.Create(
           propertyName: "IsNestedScroll",
           returnType: typeof(bool),
           declaringType: typeof(CustomListView),
           defaultValue: false
           );
        public bool IsNestedScroll
        {
            get
            {
                return (bool)GetValue(IsNestedScrollProperty);
            }
            set
            {
                SetValue(IsNestedScrollProperty, value);
            }
        }
    }
