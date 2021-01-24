	public static BindableProperty<TProperty> Watch<TInstance, TProperty>(this TInstance instance,
		Expression<Func<TInstance, TProperty>> expression, BindingMode mode = BindingMode.TwoWay)
	{
		return new BindableProperty<TProperty>(instance, GetPath((MemberExpression)expression.Body), mode);
	}
	public static void BindTo<TInstance, TProperty>(this BindableProperty<TProperty> bindable,
		TInstance instance,
		Expression<Func<TInstance, TProperty>> expression) where TInstance : DependencyObject
	{
		var getterBody = expression.Body;
		var propertyInfo = (PropertyInfo)((MemberExpression)getterBody).Member;
	   var name = propertyInfo.Name;
		var dependencyPropertyName = name + "Property";
		var fieldInfo = typeof(TInstance).GetField(dependencyPropertyName, BindingFlags.Public | BindingFlags.Static);
		var dependencyProperty = (DependencyProperty)fieldInfo.GetValue(null);
		Binding binding = new Binding();
		binding.Source = bindable.Source;
		binding.Path = new PropertyPath(bindable.Path);
		binding.Mode = bindable.Mode;
		binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
		BindingOperations.SetBinding(instance, dependencyProperty, binding);
	}
	
	public class BindableProperty<T>
	{
		public object Source { get; }
		public string Path { get; }
		public BindingMode Mode { get; }
		public BindableProperty(object source, string path, BindingMode mode)
		{
			Source = source;
			Path = path;
			Mode = mode;
		}
	}
	
