    <ControlTemplate TargetType="{x:Type local:LoadingControl}">
        <ControlTemplate.Triggers>
            <Trigger Property="IsLoading" Value="True">
                <Trigger.EnterActions>
                    <RemoveStoryboard BeginStoryboardName="EndAnimateLoadingCanvas" />
                    <BeginStoryboard Name="AnimateLoadingCanvas">
                        <Storyboard FillBehavior="Stop">
                            <ObjectAnimationUsingKeyFrames BeginTime="00:00:00"
                                       Storyboard.TargetName="MyViewBoxje"
                                       Storyboard.TargetProperty="Visibility">
                                <DiscreteObjectKeyFrame Value="{x:Static Visibility.Visible}" />
                            </ObjectAnimationUsingKeyFrames>
                            <DoubleAnimation BeginTime="00:00:00"
                                         Duration="00:00:00.5"
                                         Storyboard.TargetName="MyViewBoxje"
                                         Storyboard.TargetProperty="Opacity"
                                         From="0"
                                         To="1" />
                            <DoubleAnimation BeginTime="00:00:00"
                                             Duration="00:00:02"
                                             Storyboard.TargetName="AnimatedRotateTransform"
                                             Storyboard.TargetProperty="Angle"
                                             From="360"
                                             To="0"
                                             RepeatBehavior="Forever" />
                        </Storyboard>
                    </BeginStoryboard>
                </Trigger.EnterActions>
                <Trigger.ExitActions>
                    <RemoveStoryboard BeginStoryboardName="AnimateLoadingCanvas" />
                    <BeginStoryboard Name="EndAnimateLoadingCanvas">
                        <Storyboard FillBehavior="Stop">
                            <DoubleAnimation BeginTime="00:00:00"
                                             Duration="00:00:00.5"
                                             Storyboard.TargetName="MyViewBoxje"
                                             Storyboard.TargetProperty="Opacity"
                                             From="1"
                                            To="0" />
                            <ObjectAnimationUsingKeyFrames BeginTime="00:00:00.5"
                                       Storyboard.TargetName="MyViewBoxje"
                                       Storyboard.TargetProperty="Visibility">
                                <DiscreteObjectKeyFrame Value="{x:Static Visibility.Collapsed}" />
                            </ObjectAnimationUsingKeyFrames>
                        </Storyboard>
                    </BeginStoryboard>
                </Trigger.ExitActions>
            </Trigger>
        </ControlTemplate.Triggers>
        
        <Border Background="{TemplateBinding Background}"
                BorderBrush="{TemplateBinding BorderBrush}"
                BorderThickness="{TemplateBinding BorderThickness}">
            <Viewbox x:Name="MyViewBoxje" Opacity="0">
                <!-- BG with 0x50 alpha so that it's translucent event at 100% visibility -->
                <Grid Width="100" Height="100" Background="#50000000">
                    <Rectangle Width="70" Height="20" Fill="Green" Stroke="Black" StrokeThickness="2" RenderTransformOrigin="0.5,0.5">
                        <Rectangle.RenderTransform>
                            <RotateTransform Angle="360" x:Name="AnimatedRotateTransform" />
                        </Rectangle.RenderTransform>
                    </Rectangle>
                </Grid>
            </Viewbox>
        </Border>
    </ControlTemplate>
