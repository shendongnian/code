	[ContentProperty("Settings")]
	public class CallMethodActionExtension : MarkupExtension
	{
		//Needed to provide dependency properties as MarkupExtensions cannot have any
		public CallMethodActionSettings Settings { get; set; }
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return new Action(() =>
				{
					bool staticCall = Settings.TargetObject == null;
					var argsCast = Settings.MethodArguments.Cast<object>();
					var types = argsCast.Select(x => x.GetType()).ToArray();
					var args = argsCast.ToArray();
					MethodInfo method;
					if (staticCall)
					{
						method = Settings.TargetType.GetMethod(Settings.MethodName, types);
					}
					else
					{
						method = Settings.TargetObject.GetType().GetMethod(Settings.MethodName, types);
					}
					method.Invoke(Settings.TargetObject, args);
				});
		}
	}
	public class CallMethodActionSettings : DependencyObject
	{
		public static readonly DependencyProperty MethodNameProperty =
			DependencyProperty.Register("MethodName", typeof(string), typeof(CallMethodActionSettings), new UIPropertyMetadata(null));
		public string MethodName
		{
			get { return (string)GetValue(MethodNameProperty); }
			set { SetValue(MethodNameProperty, value); }
		}
		public static readonly DependencyProperty TargetObjectProperty =
			DependencyProperty.Register("TargetObject", typeof(object), typeof(CallMethodActionSettings), new UIPropertyMetadata(null));
		public object TargetObject
		{
			get { return (object)GetValue(TargetObjectProperty); }
			set { SetValue(TargetObjectProperty, value); }
		}
		public static readonly DependencyProperty TargetTypeProperty =
			DependencyProperty.Register("TargetType", typeof(Type), typeof(CallMethodActionSettings), new UIPropertyMetadata(null));
		public Type TargetType
		{
			get { return (Type)GetValue(TargetTypeProperty); }
			set { SetValue(TargetTypeProperty, value); }
		}
		public static readonly DependencyProperty MethodArgumentsProperty =
			DependencyProperty.Register("MethodArguments", typeof(IList), typeof(CallMethodActionSettings), new UIPropertyMetadata(null));
		public IList MethodArguments
		{
			get { return (IList)GetValue(MethodArgumentsProperty); }
			set { SetValue(MethodArgumentsProperty, value); }
		}
		public CallMethodActionSettings()
		{
			MethodArguments = new List<object>();
		}
	}
