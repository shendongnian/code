    <Image    x:Name="ImageControl" Grid.Row="0" MaxHeight="50" Source="..\Images\Propeller.png" 
       RenderTransformOrigin=".5,.5"  >
                <Image.RenderTransform>
                    <RotateTransform   Angle="0" />
                </Image.RenderTransform>
                <Image.Triggers>
                    <EventTrigger RoutedEvent="Loaded">
                        <BeginStoryboard>
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
                </Image.Triggers>
            </Image>
 
