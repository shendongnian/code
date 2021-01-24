xml
<Grid>
    <Grid HorizontalAlignment="Center" VerticalAlignment="Center" BorderBrush="Gray" BorderThickness="1" Padding="10">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <Image Source="ms-appx:///Assets/StoreLogo.png" Width="100" Height="100" VerticalAlignment="Center"/>
        <StackPanel Grid.Column="1" Margin="20,0,0,0" VerticalAlignment="Center">
            <ScrollViewer Width="200" 
                          PointerEntered="ScrollViewer_PointerEntered" 
                          HorizontalScrollBarVisibility="Hidden" 
                          VerticalScrollBarVisibility="Hidden" 
                          PointerExited="ScrollViewer_PointerExited">
                <TextBlock FontSize="25" x:Name="TitleBlock">
                    <TextBlock.RenderTransform>
                        <TranslateTransform X="0"/>
                    </TextBlock.RenderTransform>
                </TextBlock>
            </ScrollViewer>
            
            <TextBlock FontSize="20" FontWeight="Bold" Text="Gotye" Margin="0,10,0,0"/>
        </StackPanel>
    </Grid>
</Grid>
**xaml.cs**
csharp
Storyboard _scrollAnimation;
public ScrollTextPage()
{
    this.InitializeComponent();
    string text = "How about you?";
    TitleBlock.Text = text + "    " + text;
}
private void ScrollViewer_PointerEntered(object sender, PointerRoutedEventArgs e)
{
    AnimationInit();
    _scrollAnimation.Begin();
}
private void ScrollViewer_PointerExited(object sender, PointerRoutedEventArgs e)
{
    _scrollAnimation.Stop();
}
public void AnimationInit()
{
    _scrollAnimation = new Storyboard();
    var animation = new DoubleAnimation();
    animation.Duration = TimeSpan.FromSeconds(5);
    animation.RepeatBehavior = new RepeatBehavior(1);
    animation.From = 0;
    // Here you need to calculate based on the number of spaces and the current FontSize
    animation.To = -((TitleBlock.ActualWidth/2)+13);
    Storyboard.SetTarget(animation, TitleBlock);
    Storyboard.SetTargetProperty(animation, "(UIElement.RenderTransform).(TranslateTransform.X)");
    _scrollAnimation.Children.Add(animation);
}
Simply put, scrolling the TextBlock horizontally is more controllable than scrolling the ScrollViewer. 
The idea is similar to yours, using a string stitching method to achieve seamless scrolling, and calculate the width of the space by the current font size, so as to accurately scroll to the beginning of the second string.
Best regards.
