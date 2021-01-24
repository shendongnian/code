public class MyValidationRule : ValidationRule
{
    public int MinimalLength { get; set; }
    public int MaximalLength { get; set; }
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        if(value is string validatedString)
        {
            if (validatedString.Length < MinimalLength)
                return new ValidationResult(false, "Text must be larger.");
            if (validatedString.Length > MaximalLength)
                return new ValidationResult(false, "Text must be shorter.");
        }
        return new ValidationResult(true, "");
    }
}
<b>xaml:</b>
<Window x:Class="WpfApp15.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApp15"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Window.DataContext>
        <local:MainWindowViewModel/>
    </Window.DataContext>
    <Window.Resources>
        <Style x:Key="textBoxInError" TargetType="{x:Type TextBox}">
            <Style.Triggers>
                <Trigger Property="Validation.HasError" Value="true">
                    <Setter Property="ToolTip"
        Value="{Binding RelativeSource={x:Static RelativeSource.Self},
                        Path=(Validation.Errors)/ErrorContent}"/>
                </Trigger>
            </Style.Triggers>
        </Style>
    </Window.Resources>
    <Grid>
        <TextBox Margin="10" Style="{StaticResource textBoxInError}">
            <TextBox.Text>
                <Binding Path="Text" UpdateSourceTrigger="PropertyChanged" Mode="TwoWay">
                    <Binding.ValidationRules>
                        <local:MyValidationRule MinimalLength="2" MaximalLength="10"/>
                    </Binding.ValidationRules>
                </Binding>
            </TextBox.Text>
        </TextBox>
    </Grid>
</Window>
The binded property must have an implementation of the INotifyPropertyChanged interface.
