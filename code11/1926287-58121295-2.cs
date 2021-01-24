XAML
<Button Click="Rectangle_Click">
    <Button.Template>
        <ControlTemplate TargetType="Button">
            <Rectangle 
                Fill="Transparent" 
                Stroke="Blue" 
                StrokeThickness="0.5" 
                Width="{Binding Width}" 
                Height="{Binding Height}"
                />
        </ControlTemplate>
    </Button.Template>
</Button>
C#
private void Rectangle_Click(object sender, RoutedEventArgs e)
{
    var button = sender as Button;
    var square = button.DataContext as Square;
    //  Do whatever
}
It would be preferable to give `Square` a command property, and bind Button.Command to that:
C#
public class Square
{
    //  stuff
    public ICommand SelectCommand { get; } // Initialize in constructor
    //  stuff
}
XAML
<Button Command="{Binding SelectCommand}">
<!-- ...as before... -->
But then you need to implement ICommand, etc. The Click event works well enough. 
You could also handle MouseLeftButtonDown on the Rectangle itself. You'd still have to set its Fill to Transparent. I prefer this solution because Click behavior is more complicated than MouseLeftButtonDown: For example, when you mouse down on 
a button and drag out of the button before releasing the mouse button, Click isn't raised. Users are accustomed to that behavior. 
