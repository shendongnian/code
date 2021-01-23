        public class Timeline : ItemsControl
            {
                protected override System.Windows.DependencyObject GetContainerForItemOverride()
                {
                    return new ContentControl();
                }
        
                protected override void PrepareContainerForItemOverride(System.Windows.DependencyObject element, object item)
                {
                    var control = element as Control;
                    if (control != null)
                    {
                        var myUri = new Uri("/ResourceDictionary.xaml", UriKind.Relative);
                        var dictionary = Application.LoadComponent(myUri) as ResourceDictionary;
                        
                        if (dictionary != null)
                        {
                            control.Template = (ControlTemplate)dictionary["TimelineElementTemplate"];
                        }
        
                        control.DataContext = item;
                    }
                    base.PrepareContainerForItemOverride(element, item);
                }
            }
    
    
            <ControlTemplate x:Key="TimelineElementTemplate" TargetType="{x:Type Controls:ContentControl}">
                    <Grid DataContext="{Binding RelativeSource={RelativeSource TemplatedParent}}">
                        <TextBlock Text="{Binding Path=DataContext.DebugData}"                        
                                   ToolTip="{Binding Path=DataContext.DebugData}"
                                   Background="{Binding Path=DataContext.Background}"/>
                        <Control Template="{StaticResource ResizeDecoratorTemplate}" />            
                    </Grid>
                </ControlTemplate>
        
        <Style x:Key="TimelineElementStyle" TargetType="Controls:ContentControl">
            <Setter Property="Canvas.Left">
                <Setter.Value>
                    <Binding Path="LeftPos" Mode="TwoWay"/>
                </Setter.Value>
            </Setter>
            
            <Setter Property="Width">
                <Setter.Value>
                    <Binding Path="Width" Mode="TwoWay"/>
                </Setter.Value>
            </Setter>         
        </Style>
    
    <Style x:Key="TimelineStyle" TargetType="ItemsControl">
        <Setter Property="ItemsPanel">
            <Setter.Value>
                <ItemsPanelTemplate>
                    <Canvas Background="LightGray"></Canvas>
                </ItemsPanelTemplate>
            </Setter.Value>
        </Setter>
    </Style>
        <Controls:Timeline Style="{StaticResource TimelineStyle}" 
                                   DataContext="{StaticResource timelineViewModel}"   
                                   ItemContainerStyle="{StaticResource TimelineElementStyle}"
                                   ItemsSource="{Binding ListOfTimelineElements}"
                                   HelperClasses:DragDropHelper.IsDragSource="False" 
                                   HelperClasses:DragDropHelper.IsDropTarget="True" 
                                   HelperClasses:SizeObserver.Observe="True"                 
                                   HelperClasses:SizeObserver.ObservedWidth="{Binding TotalWidth, Mode=OneWayToSource}" 
                                   BorderBrush="Black" 
                                   BorderThickness="1">
                    
                </Controls:Timeline>
