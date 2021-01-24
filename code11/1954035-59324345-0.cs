<Editor Text="{Binding editorText,Mode=TwoWay}"... />
###in model
define a new property
    public class Team  : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string property)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(property));
		}
		string editorText;
		public string EditorText
		{
			get
			{
				return editorText;
			}
			set
			{
				if(value!=null)
				{
					editorText = value;
					OnPropertyChanged("EditorText");
				}
			}
		}
        //...
      }
> When editor is opened, datagrid selectedItem event is not working.
This maybe a issue of the plugin . You could set the `SelectItem` when the editor is focused .
Add the following class in your project
using System;
using Xamarin.Forms;
namespace xxx
{
	public class BehaviorBase<T> : Behavior<T> where T : BindableObject
	{
		public T AssociatedObject { get; private set; }
		protected override void OnAttachedTo (T bindable)
		{
			base.OnAttachedTo (bindable);
			AssociatedObject = bindable;
			if (bindable.BindingContext != null) {
				BindingContext = bindable.BindingContext;
			}
			bindable.BindingContextChanged += OnBindingContextChanged;
		}
		protected override void OnDetachingFrom (T bindable)
		{
			base.OnDetachingFrom (bindable);
			bindable.BindingContextChanged -= OnBindingContextChanged;
			AssociatedObject = null;
		}
		void OnBindingContextChanged (object sender, EventArgs e)
		{
			OnBindingContextChanged ();
		}
		protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();
			BindingContext = AssociatedObject.BindingContext;
		}
	}
}
using System;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;
namespace xxx
{
	public class EventToCommandBehavior : BehaviorBase<View>
	{
		Delegate eventHandler;
		public static readonly BindableProperty EventNameProperty = BindableProperty.Create ("EventName", typeof(string), typeof(EventToCommandBehavior), null, propertyChanged: OnEventNameChanged);
		public static readonly BindableProperty CommandProperty = BindableProperty.Create ("Command", typeof(ICommand), typeof(EventToCommandBehavior), null);
		public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create ("CommandParameter", typeof(object), typeof(EventToCommandBehavior), null);
		public static readonly BindableProperty InputConverterProperty = BindableProperty.Create ("Converter", typeof(IValueConverter), typeof(EventToCommandBehavior), null);
		public string EventName {
			get { return (string)GetValue (EventNameProperty); }
			set { SetValue (EventNameProperty, value); }
		}
		public ICommand Command {
			get { return (ICommand)GetValue (CommandProperty); }
			set { SetValue (CommandProperty, value); }
		}
		public object CommandParameter {
			get { return GetValue (CommandParameterProperty); }
			set { SetValue (CommandParameterProperty, value); }
		}
		public IValueConverter Converter {
			get { return (IValueConverter)GetValue (InputConverterProperty); }
			set { SetValue (InputConverterProperty, value); }
		}
		protected override void OnAttachedTo (View bindable)
		{
			base.OnAttachedTo (bindable);
			RegisterEvent (EventName);
		}
		protected override void OnDetachingFrom (View bindable)
		{
			DeregisterEvent (EventName);
			base.OnDetachingFrom (bindable);
		}
		void RegisterEvent (string name)
		{
			if (string.IsNullOrWhiteSpace (name)) {
				return;
			}
			EventInfo eventInfo = AssociatedObject.GetType ().GetRuntimeEvent (name);
			if (eventInfo == null) {
				throw new ArgumentException (string.Format ("EventToCommandBehavior: Can't register the '{0}' event.", EventName));
			}
			MethodInfo methodInfo = typeof(EventToCommandBehavior).GetTypeInfo ().GetDeclaredMethod ("OnEvent");
			eventHandler = methodInfo.CreateDelegate (eventInfo.EventHandlerType, this);
			eventInfo.AddEventHandler (AssociatedObject, eventHandler);
		}
		void DeregisterEvent (string name)
		{
			if (string.IsNullOrWhiteSpace (name)) {
				return;
			}
			if (eventHandler == null) {
				return;
			}
			EventInfo eventInfo = AssociatedObject.GetType ().GetRuntimeEvent (name);
			if (eventInfo == null) {
				throw new ArgumentException (string.Format ("EventToCommandBehavior: Can't de-register the '{0}' event.", EventName));
			}
			eventInfo.RemoveEventHandler (AssociatedObject, eventHandler);
			eventHandler = null;
		}
		void OnEvent (object sender, object eventArgs)
		{
			if (Command == null) {
				return;
			}
			object resolvedParameter;
			if (CommandParameter != null) {
				resolvedParameter = CommandParameter;
			} else if (Converter != null) {
				resolvedParameter = Converter.Convert (eventArgs, typeof(object), null, null);
			} else {
				resolvedParameter = eventArgs;
			}		
			if (Command.CanExecute (resolvedParameter)) {
				Command.Execute (resolvedParameter);
			}
		}
		static void OnEventNameChanged (BindableObject bindable, object oldValue, object newValue)
		{
			var behavior = (EventToCommandBehavior)bindable;
			if (behavior.AssociatedObject == null) {
				return;
			}
			string oldEventName = (string)oldValue;
			string newEventName = (string)newValue;
			behavior.DeregisterEvent (oldEventName);
			behavior.RegisterEvent (newEventName);
		}
	}
}
### in xaml
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:d="http://xamarin.com/schemas/2014/forms/design"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             xmlns:local="clr-namespace:xxx"
             mc:Ignorable="d"
             x:Name="page"  // set name here
             x:Class="xxx.MainPage">
<Editor.Behaviors>
    <local:EventToCommandBehavior EventName="Focused" Command="{Binding Source={x:Reference page},Path=BindingContext.xxxCommand}" CommandParameter="{Binding }" />
                                  
</Editor.Behaviors>
### in ViewModel
xxxCommand = new Command((model)=>{
   var item = model as Team;
   SelectedTeam = item;
   //  ...
});
