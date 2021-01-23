	public class EventBindingExtension : MarkupExtension
	{
		private static readonly MethodInfo EventHandlerImplMethod = typeof(EventBindingExtension).GetMethod(nameof(EventHandlerImpl), new[] { typeof(object), typeof(string) });
		public string Command { get; set; }
		public EventBindingExtension()
		{
		}
		public EventBindingExtension(string command) : this()
		{
			Command = command;
		}
		// Do not use!!
		public static void EventHandlerImpl(object sender, string commandName)
		{
			if (sender is FrameworkElement frameworkElement)
			{
				object dataContext = frameworkElement.DataContext;
				if (dataContext?.GetType().GetProperty(commandName)?.GetValue(dataContext) is ICommand command)
				{
					object commandParameter = (frameworkElement as ICommandSource)?.CommandParameter;
					if (command.CanExecute(commandParameter)) command.Execute(commandParameter);
				}
			}
		}
		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			if (serviceProvider.GetService(typeof(IProvideValueTarget)) is IProvideValueTarget targetProvider &&
				targetProvider.TargetObject is FrameworkElement targetObject &&
				targetProvider.TargetProperty is MemberInfo memberInfo)
			{
				Type eventHandlerType;
				if (memberInfo is EventInfo eventInfo) eventHandlerType = eventInfo.EventHandlerType;
				else if (memberInfo is MethodInfo methodInfo) eventHandlerType = methodInfo.GetParameters()[1].ParameterType;
				else return null;
				MethodInfo handler = eventHandlerType.GetMethod("Invoke");
				DynamicMethod method = new DynamicMethod("", handler.ReturnType, new[] { typeof(object), typeof(object) });
				ILGenerator ilGenerator = method.GetILGenerator();
				ilGenerator.Emit(OpCodes.Ldarg, 0);
				ilGenerator.Emit(OpCodes.Ldstr, Command);
				ilGenerator.Emit(OpCodes.Call, EventHandlerImplMethod);
				ilGenerator.Emit(OpCodes.Ret);
				return method.CreateDelegate(eventHandlerType);
			}
			else
			{
				throw new InvalidOperationException("Could not create event binding.");
			}
		}
	}
