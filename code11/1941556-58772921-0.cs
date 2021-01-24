    public class UpdateBindingAction : TriggerAction<FrameworkElement>
    {
        public FrameworkElement Target
        {
            get { return (FrameworkElement)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }
        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register(nameof(Target), typeof(FrameworkElement), typeof(UpdateBindingAction), new PropertyMetadata(null));
        public string PropertyName
        {
            get { return (string)GetValue(PropertyNameProperty); }
            set { SetValue(PropertyNameProperty, value); }
        }
        public static readonly DependencyProperty PropertyNameProperty =
            DependencyProperty.Register("PropertyName", typeof(string), typeof(UpdateBindingAction), new PropertyMetadata(null));
        protected override void Invoke(object parameter)
        {
            if (Target == null)
                return;
            if (string.IsNullOrEmpty(PropertyName))
                return;
            var propertyDescriptor = DependencyPropertyDescriptor.FromName(PropertyName, Target.GetType(), Target.GetType());
            if (propertyDescriptor == null)
                return;
            Target.GetBindingExpression(propertyDescriptor.DependencyProperty).UpdateSource();
        }
    }
Then, create a binding in XAML that doesn't update automatically
<TextBox x:Name="txt1" Width="200" Text="{Binding String1, Mode=TwoWay, UpdateSourceTrigger=Explicit}" />
<TextBox x:Name="txt2" Width="200" Text="{Binding String2, Mode=TwoWay, UpdateSourceTrigger=Explicit}" />
Last, create a button that contains an EventTrigger for the Click-Event, which executes the UpdateSourceAction(s). The "b:" namespace is `xmlns:b="http://schemas.microsoft.com/xaml/behaviors"` (from Microsoft.Xaml.Behaviors.Wpf), the "local:" namespace is the one where you put the UpdateBindingAction.
        <Button Margin="10" Content="Update">
            <b:Interaction.Triggers>
                <b:EventTrigger EventName="Click">
                    <local:UpdateBindingAction Target="{Binding ElementName=txt1}" PropertyName="Text" />
                    <local:UpdateBindingAction Target="{Binding ElementName=txt2}" PropertyName="Text" />
                    <!-- ... -->
                </b:EventTrigger>
            </b:Interaction.Triggers>
        </Button>
There's some generic built-in triggers (EventTrigger, PropertyChangedTrigger, ...) and actions (ChangePropertyAction, CallMethodAction, ...), but it is very possible to implement your own additions, like this one.
  [1]: https://github.com/microsoft/XamlBehaviorsWpf
