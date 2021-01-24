csharp
public class VisualStateExtensions : DependencyObject
{
    public static void SetVisualStatefromTemplate(UIElement element, DataTemplate value)
    {
        element.SetValue(VisualStatefromTemplateProperty, value);
    }
    public static DataTemplate GetVisualStatefromTemplate(UIElement element)
    {
        return (DataTemplate)element.GetValue(VisualStatefromTemplateProperty);
    }
    public static readonly DependencyProperty VisualStatefromTemplateProperty =
        DependencyProperty.RegisterAttached("VisualStatefromTemplate", typeof(DataTemplate), typeof(VisualStateExtensions), new PropertyMetadata(null,new PropertyChangedCallback(VisualStatefromTemplateChanged)));
    private static void VisualStatefromTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is FrameworkElement frameworkElement)
        {
            var visualStateGroups = VisualStateManager.GetVisualStateGroups(frameworkElement);
            if (visualStateGroups != null)
            {
                var template = (DataTemplate)e.NewValue;
                var content = (FrameworkElement)template.LoadContent();
                var groups = VisualStateManager.GetVisualStateGroups(content);
                if (groups!=null && groups.Count>0)
                {
                    var original = groups.First();
                    groups.Remove(original);
                    visualStateGroups.Add(original);
                }
            }
        }
    }
}
**Usage**
App.xaml
xml
...
<DataTemplate x:Key="VisualStateTemplate">
    <Grid>
        <VisualStateManager.VisualStateGroups>
            <VisualStateGroup >
                <VisualState x:Name="NarrowView" >
                    <VisualState.StateTriggers>
                        <AdaptiveTrigger MinWindowWidth="0" />
                    </VisualState.StateTriggers>
                    <VisualState.Setters>
                        <Setter Target="Header.FontSize" Value="20" />
                    </VisualState.Setters>
                </VisualState>
                <VisualState x:Name="WideView">
                    <VisualState.StateTriggers>
                        <AdaptiveTrigger MinWindowWidth="1000" />
                    </VisualState.StateTriggers>
                    <VisualState.Setters>
                        <Setter Target="Header.FontSize" Value="30" />
                    </VisualState.Setters>
                </VisualState>
            </VisualStateGroup>
        </VisualStateManager.VisualStateGroups>
    </Grid>
</DataTemplate>
...
MainPage.xaml
xml
<Grid controls:VisualStateExtensions.VisualStatefromTemplate="{StaticResource VisualStateTemplate}">
    <TextBlock x:Name="Header" Text="Hello World!"/>
</Grid>
Best regards.
