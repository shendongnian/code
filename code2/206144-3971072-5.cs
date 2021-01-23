    <TextBlock Name="statusText" Text="{Binding Path=StatusBarText, NotifyOnTargetUpdated=True}">
            <TextBlock.Triggers>
                <EventTrigger RoutedEvent="Binding.TargetUpdated">
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="Opacity">
                                <EasingDoubleKeyFrame KeyTime="0" Value="0"/>
                                <EasingDoubleKeyFrame KeyTime="0:0:0.25" Value="1"/>
                                <EasingDoubleKeyFrame KeyTime="0:0:4" Value="1"/>
                                <EasingDoubleKeyFrame KeyTime="0:0:5" Value="0"/>
                            </DoubleAnimationUsingKeyFrames>
                        </Storyboard>
                    </BeginStoryboard>
                </EventTrigger>
            </TextBlock.Triggers>
