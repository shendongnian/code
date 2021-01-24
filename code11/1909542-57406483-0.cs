c#
class ViewModel : NotifyPropertyChangedBase
{
    private string _text;
    public string Text
    {
        get => _text;
        set => _UpdateField(ref _text, value);
    }
    private bool _isHighlighted;
    public bool IsHighlighted
    {
        get => _isHighlighted;
        set => _UpdateField(ref _isHighlighted, value);
    }
    private bool _isAnimating;
    public bool IsAnimating
    {
        get => _isAnimating;
        set => _UpdateField(ref _isAnimating, value, _OnIsAnimatingChanged);
    }
    private void _OnIsAnimatingChanged(bool oldValue)
    {
        _toggleIsHighlightedCommand.RaiseCanExecuteChanged();
        _animateIsHighlightedCommand.RaiseCanExecuteChanged();
    }
    private readonly DelegateCommand _toggleIsHighlightedCommand;
    private readonly DelegateCommand _animateIsHighlightedCommand;
    public ICommand ToggleIsHighlightedCommand => _toggleIsHighlightedCommand;
    public ICommand AnimateIsHighlightedCommand => _animateIsHighlightedCommand;
    public ViewModel()
    {
        _toggleIsHighlightedCommand = new DelegateCommand(() => IsHighlighted = !IsHighlighted, () => !IsAnimating);
        _animateIsHighlightedCommand = new DelegateCommand(() => _FlashIsHighlighted(this), () => !IsAnimating);
    }
    private static async void _FlashIsHighlighted(ViewModel viewModel)
    {
        viewModel.IsAnimating = true;
        for (int i = 0; i < 10; i++)
        {
            viewModel.IsHighlighted = !viewModel.IsHighlighted;
            await Task.Delay(200);
        }
        viewModel.IsAnimating = false;
    }
}
class NotifyPropertyChangedBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    protected void _UpdateField<T>(ref T field, T newValue,
        Action<T> onChangedCallback = null,
        [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, newValue))
        {
            return;
        }
        T oldValue = field;
        field = newValue;
        onChangedCallback?.Invoke(oldValue);
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
class DelegateCommand : ICommand
{
    private readonly Action _execute;
    private readonly Func<bool> _canExecute;
    public DelegateCommand(Action execute, Func<bool> canExecute)
    {
        _execute = execute;
        _canExecute = canExecute;
    }
    public DelegateCommand(Action execute) : this(execute, null) { }
    public event EventHandler CanExecuteChanged;
    public bool CanExecute(object parameter) => _canExecute?.Invoke() != false;
    public void Execute(object parameter) => _execute?.Invoke();
    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
The second class there, `NotifyPropertyChangedBase`, is just my standard base class for my view models. It contains all the boilerplate to support the `INotifyPropertyChanged` interface. There are WPF frameworks that include such a base class themselves; why WPF doesn't itself provide one, I don't know. But it's handy to have, and between it and a Visual Studio code snippet to paste in the property template, it makes it a lot faster to put together the view models for a program.
Similarly, the third class, `DelegateCommand`, makes it easier to define `ICommand` objects. Again, this type of class is available in third-party WPF frameworks as well. (I also have a version of the class that is generic with the type parameter specifying the type of the command parameter passed to the `CanExecute()` and `Execute()` methods, but since we don't need that here, I didn't bother to include it.
As you can see, once you get past the boilerplate, the code's pretty simple. It has a pro-forma `Text` property just so I have something to bind to the `TextBox` in my UI. It also has a couple of `bool` properties that relate to the visual state of the `TextBox`. One determines the actual visual state, while the other provides some indication as to whether that state is currently being animated.
There are two `ICommand` instances providing user interaction with the view model. One just toggles the visual state, while the other causes the animation you want to happen.
Finally, there's the method that actually does the work. It first sets the `IsAnimating` property, then loops ten times to toggle the `IsHighlighted` property. This method uses `async`. In a Winforms program, this would be essential, so that the UI property updates happened in the UI thread. But in this WPF program, it's optional. I like the async/await programming model, but for simple property-change notifications, WPF will marshal the binding update back to the UI thread as necessary, so you could in fact just create a background task in the thread pool or a dedicated thread to handle the animation.
(For the animation, I used 200 ms between frames instead of 100 as your code would've, just because I think it looks better, and in any case makes it easier to see what the animation is doing.)
Note that the view model itself has no idea there's a UI involved per se. It just has a property that indicates whether the text box should be highlighted or not. It's up to the UI to figure out how to do that.
And that, looks like this:
xaml
<Window x:Class="TestSO57403045FlashBorderBackground.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:p="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:l="clr-namespace:TestSO57403045FlashBorderBackground"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
  <Window.DataContext>
    <l:ViewModel/>
  </Window.DataContext>
  <StackPanel>
    <Button Command="{Binding ToggleIsHighlightedCommand}" Content="Toggle Control" HorizontalAlignment="Left"/>
    <Button Command="{Binding AnimateIsHighlightedCommand}" Content="Flash Control" HorizontalAlignment="Left"/>
    <TextBox x:Name="textBox1" Width="100" Text="{Binding Text}" HorizontalAlignment="Left">
      <TextBox.Style>
        <p:Style TargetType="TextBox">
          <Setter Property="BorderBrush" Value="Black"/>
          <Setter Property="BorderThickness" Value="2"/>
          <Setter Property="Background" Value="WhiteSmoke"/>
          <p:Style.Triggers>
            <DataTrigger Binding="{Binding IsHighlighted}" Value="True">
              <Setter Property="BorderBrush" Value="IndianRed"/>
              <Setter Property="Background" Value="Red"/>
            </DataTrigger>
          </p:Style.Triggers>
        </p:Style>
      </TextBox.Style>
    </TextBox>
  </StackPanel>
</Window>
This just sets some default values for the border and background colors. And then, importantly, it defines a data trigger that will temporarily override these defaults any time the condition in the data trigger is true. That is, the declared binding evaluates to the declared value given (which in my example above is in fact the `bool` value of `true`).
Every place you see an element property set to something that looks like `{Binding}`, that's a reference back to the current data context, which in this case is set to my view model class.
Now, WPF has a very rich animation feature set, and that can be used instead of the above to handle the flashing animation. If we're going to do it that way, then the view model can be simpler, as we don't need the explicit property for the highlighted state. We do still need the `IsAnimating` property, but this time instead of the "animate" command calling a method, which sets this property as a side-effect, the command sets the property directly and does nothing else (and that property, now the primary controller for the animation, still does serve as the flag so that the button's command can be enabled/disabled as needed):
c#
class ViewModel : NotifyPropertyChangedBase
{
    private string _text;
    public string Text
    {
        get => _text;
        set => _UpdateField(ref _text, value);
    }
    private bool _isAnimating;
    public bool IsAnimating
    {
        get => _isAnimating;
        set => _UpdateField(ref _isAnimating, value, _OnIsAnimatingChanged);
    }
    private void _OnIsAnimatingChanged(bool oldValue)
    {
        _animateIsHighlightedCommand.RaiseCanExecuteChanged();
    }
    private readonly DelegateCommand _animateIsHighlightedCommand;
    public ICommand AnimateIsHighlightedCommand => _animateIsHighlightedCommand;
    public ViewModel()
    {
        _animateIsHighlightedCommand = new DelegateCommand(() => IsAnimating = true, () => !IsAnimating);
    }
}
Importantly, you'll notice that now the view model doesn't contain any code to actually run the animation. That, we'll find in the XAML:
xaml
<Window x:Class="TestSO57403045FlashBorderBackground.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:p="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:l="clr-namespace:TestSO57403045FlashBorderBackground"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
  <Window.DataContext>
    <l:ViewModel/>
  </Window.DataContext>
  <Window.Resources>
    <Storyboard x:Key="flashBorder" RepeatBehavior="5x"
                Completed="flashStoryboard_Completed">
      <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Background).(SolidColorBrush.Color)"
                                    Duration="0:0:0.4">
        <DiscreteColorKeyFrame KeyTime="0:0:0" Value="IndianRed"/>
        <DiscreteColorKeyFrame KeyTime="0:0:0.2" Value="WhiteSmoke"/>
      </ColorAnimationUsingKeyFrames>
      <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(BorderBrush).(SolidColorBrush.Color)"
                                    Duration="0:0:0.4">
        <DiscreteColorKeyFrame KeyTime="0:0:0" Value="Red"/>
        <DiscreteColorKeyFrame KeyTime="0:0:0.2" Value="Black"/>
      </ColorAnimationUsingKeyFrames>
    </Storyboard>
  </Window.Resources>
  <StackPanel>
    <Button Command="{Binding AnimateIsHighlightedCommand}" Content="Flash Control" HorizontalAlignment="Left"/>
    <TextBox x:Name="textBox1" Width="100" Text="{Binding Text}" HorizontalAlignment="Left">
      <TextBox.Style>
        <p:Style TargetType="TextBox">
          <Setter Property="BorderBrush" Value="Black"/>
          <Setter Property="BorderThickness" Value="2"/>
          <Setter Property="Background" Value="WhiteSmoke"/>
          <p:Style.Triggers>
            <DataTrigger Binding="{Binding IsAnimating}" Value="True">
              <DataTrigger.EnterActions>
                <BeginStoryboard Storyboard="{StaticResource flashBorder}" Name="flashBorderBegin"/>
              </DataTrigger.EnterActions>
              <DataTrigger.ExitActions>
                <StopStoryboard BeginStoryboardName="flashBorderBegin"/>
              </DataTrigger.ExitActions>
            </DataTrigger>
          </p:Style.Triggers>
        </p:Style>
      </TextBox.Style>
    </TextBox>
  </StackPanel>
</Window>
In this case, there's a `Storyboard` object which contains two animation sequences (both are started simultaneously) that do the actual flashing of the control. The storyboard itself lets you specify how many times it should repeat (`"5x"` in this case, for five times), and then within each animation sequence, the duration of the whole sequence (400 ms, since one sequence involves two states, each displayed for 200 ms), and then the "key frames" that dictate what actually happens during the animation, each specifying at what time during the animation it should take effect.
Then, in the text box's style, instead of triggering property setters, the storyboard is started and stopped according to the trigger state (entered or exited).
Note that in the storyboard, the `Completed` event is subscribed to. Whereas in the previous example, there was no change to the default `MainWindow.xaml.cs` file, for this version there's a little bit of code:
c#
public partial class MainWindow : Window
{
    private readonly ViewModel _viewModel;
    public MainWindow()
    {
        InitializeComponent();
        _viewModel = (ViewModel)DataContext;
    }
    private void flashStoryboard_Completed(object sender, EventArgs e)
    {
        _viewModel.IsAnimating = false;
    }
}
This has the implementation of the event handler for the `Storyboard.Completed` event. And since that handler is going to need to modify the view model state, there is now code to retrieve the view model from the `DataContext` property and save it in a field so that the event handler can get at it.
This event handler is what allows the `IsAnimating` property to be set back to `false` once the animation has completed.
So, there you go. It is possible that there's a better way to do this, but I think these two examples should give you a good place to start in terms of seeing how things "ought to be done" in WPF.
(I'll admit, the one thing that really bugs me about the animation approach is that I'd rather not have to explicitly state in the storyboard the original colors for the text box; but I'm not aware of any way to specify a key frame in the `<ColorAnimationUsingKeyFrame/>` element that instead of actually setting a new color, just _removes_ whatever changes the animation had already applied.)
 
  [1]: https://stackoverflow.com/questions/57403045/how-to-flash-a-richtextbox-border-and-background-colors-in-wpf#comment101288794_57403045
  [2]: https://stackoverflow.com/help/minimal-reproducible-example
