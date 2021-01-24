         <Image.Triggers>
            <EventTrigger RoutedEvent="Loaded">
                <BeginStoryboard x:Name="BeginImageRotateAni" >
                    <Storyboard x:Name="MyStoryboard">
                        <DoubleAnimation x:Name="Prope11" 
                        Storyboard.TargetName="ImageControl"         
                          Storyboard.TargetProperty="(UIElement.RenderTransform).(RotateTransform.Angle)" 
                             To="360" 
                             Duration="0:0:6"
                             RepeatBehavior="Forever"
                             FillBehavior="Stop"
                               >
                        </DoubleAnimation>
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
            <EventTrigger RoutedEvent="MouseDown">
                <EventTrigger.Actions>
                    <StopStoryboard BeginStoryboardName="BeginImageRotateAni"/>
                   
                </EventTrigger.Actions>
            </EventTrigger>
        </Image.Triggers>
