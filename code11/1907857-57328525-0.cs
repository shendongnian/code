c#
public class MethodDelegation : DependencyObject
{
    public static readonly DependencyProperty CommandDelegatesProperty = 
        DependencyProperty.RegisterAttached("CommandDelegatesInternal", typeof(CommandDelegatesCollection), typeof(MethodDelegation), new PropertyMetadata(null));
    private MethodDelegation() { }
    public static CommandDelegatesCollection GetCommandDelegates(DependencyObject obj)
    {
        if (obj.GetValue(CommandDelegatesProperty) is null)
        {
            SetCommandDelegates(obj, new CommandDelegatesCollection(obj));
        }
        return (CommandDelegatesCollection)obj.GetValue(CommandDelegatesProperty);
    }
    public static void SetCommandDelegates(DependencyObject obj, CommandDelegatesCollection value)
    {
        obj.SetValue(CommandDelegatesProperty, value);
    }
}
public class CommandDelegatesCollection : FreezableCollection<CommandDelegate>
{
    public CommandDelegatesCollection()
    {
    }
    public CommandDelegatesCollection(DependencyObject targetObject)
    {
        TargetObject = targetObject;
        ((INotifyCollectionChanged)this).CollectionChanged += UpdateDelegatesTargetObjects;
    }
    public DependencyObject TargetObject { get; }
    protected override Freezable CreateInstanceCore()
    {
        return new CommandDelegatesCollection();
    }
    private void UpdateDelegatesTargetObjects(object sender, NotifyCollectionChangedEventArgs e)
    {
        foreach (CommandDelegate commandDelegate in e?.NewItems ?? Array.Empty<CommandDelegate>())
        {
            commandDelegate.TargetObject = TargetObject;
        }
    }
}
public class CommandDelegate : Freezable
{
    public static readonly DependencyProperty MethodNameProperty = 
        DependencyProperty.Register("MethodName", typeof(string), typeof(CommandDelegate), new PropertyMetadata(string.Empty, MethodName_Changed));
    public static readonly DependencyProperty CommandProperty = 
        DependencyProperty.Register("Command", typeof(ICommand), typeof(CommandDelegate), new PropertyMetadata(null));
    public static readonly DependencyProperty TargetObjectProperty = 
        DependencyProperty.Register("TargetObject", typeof(DependencyObject), typeof(CommandDelegate), new PropertyMetadata(null, TargetObject_Changed));
    private MethodInfo _method;
    public string MethodName
    {
        get { return (string)GetValue(MethodNameProperty); }
        set { SetValue(MethodNameProperty, value); }
    }
    public ICommand Command
    {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }
    public DependencyObject TargetObject
    {
        get { return (DependencyObject)GetValue(TargetObjectProperty); }
        set { SetValue(TargetObjectProperty, value); }
    }
    protected override Freezable CreateInstanceCore()
    {
        return new CommandDelegate();
    }
    private static void MethodName_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var del = (CommandDelegate)d;
        del.UpdateMethod();
        del.UpdateCommand();
    }
    private static void TargetObject_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var del = (CommandDelegate)d;
        del.UpdateMethod();
        del.UpdateCommand();
    }
    private void UpdateMethod()
    {
        _method = TargetObject?.GetType()?.GetMethod(MethodName);
    }
    private void UpdateCommand()
    {
        Command = new RelayCommand(() => _method.Invoke(TargetObject, Array.Empty<object>()));
    }
}
The XAML usage is as follows:
XAML
<TextBox>
    <l:MethodDelegation.CommandDelegates>
        <l:CommandDelegate MethodName="Focus" 
                           Command="{Binding TestCommand, Mode=OneWayToSource}" />
    </l:MethodDelegation.CommandDelegates>
</TextBox> 
