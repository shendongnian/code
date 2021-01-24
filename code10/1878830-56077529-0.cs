      <Window.Resources>
            <Style TargetType="{x:Type Button}">
                <Setter Property="Margin" Value="5" />
                <Setter Property="Background" Value="Red" />
                <Setter Property="Foreground" Value="White" />
            </Style>
            <Storyboard x:Key="Storyboard1">
                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)" Storyboard.TargetName="button">
                    <EasingDoubleKeyFrame KeyTime="0:0:0.1" Value="221"/>
                </DoubleAnimationUsingKeyFrames>
                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)" Storyboard.TargetName="button">
                    <EasingDoubleKeyFrame KeyTime="0:0:0.0001" Value="161"/>
                </DoubleAnimationUsingKeyFrames>
            </Storyboard>
            <Storyboard x:Key="Storyboard2">
                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)" Storyboard.TargetName="button">
                    <EasingDoubleKeyFrame KeyTime="0" Value="221">
                        <EasingDoubleKeyFrame.EasingFunction>
                            <ElasticEase EasingMode="EaseInOut" Oscillations="0" Springiness="0"/>
                        </EasingDoubleKeyFrame.EasingFunction>
                    </EasingDoubleKeyFrame>
                    <EasingDoubleKeyFrame KeyTime="0" Value="161">
                        <EasingDoubleKeyFrame.EasingFunction>
                            <ElasticEase EasingMode="EaseInOut" Oscillations="0" Springiness="0"/>
                        </EasingDoubleKeyFrame.EasingFunction>
                    </EasingDoubleKeyFrame>
                    <EasingDoubleKeyFrame KeyTime="0:0:0.1" Value="-3">
                        <EasingDoubleKeyFrame.EasingFunction>
                            <ElasticEase EasingMode="EaseInOut" Oscillations="0" Springiness="0"/>
                        </EasingDoubleKeyFrame.EasingFunction>
                    </EasingDoubleKeyFrame>
                    <!-- <EasingDoubleKeyFrame KeyTime="0:0:0.1" Value="0"/> -->
                </DoubleAnimationUsingKeyFrames>
                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.Y)" Storyboard.TargetName="button">
                    <EasingDoubleKeyFrame KeyTime="0" Value="156">
                        <EasingDoubleKeyFrame.EasingFunction>
                            <ElasticEase EasingMode="EaseInOut" Oscillations="0" Springiness="0"/>
                        </EasingDoubleKeyFrame.EasingFunction>
                    </EasingDoubleKeyFrame>
                    <EasingDoubleKeyFrame KeyTime="0:0:0.1" Value="-1">
                        <EasingDoubleKeyFrame.EasingFunction>
                            <ElasticEase EasingMode="EaseInOut" Oscillations="0" Springiness="0"/>
                        </EasingDoubleKeyFrame.EasingFunction>
                    </EasingDoubleKeyFrame>
                </DoubleAnimationUsingKeyFrames>
            </Storyboard>
        </Window.Resources>
        <Window.Triggers>
            <EventTrigger RoutedEvent="FrameworkElement.Loaded" SourceName="window">
                <StopStoryboard x:Name="Storyboard1_Storyboard" BeginStoryboardName="Storyboard1_Storyboard"/>
                <BeginStoryboard x:Name="Storyboard1_BeginStoryboard" Storyboard="{StaticResource Storyboard1}"/>
            </EventTrigger>
            <EventTrigger RoutedEvent="Expander.Expanded" SourceName="expander">
                <BeginStoryboard Storyboard="{StaticResource Storyboard1}"/>
            </EventTrigger>
            <EventTrigger RoutedEvent="Expander.Collapsed" SourceName="expander">
                <BeginStoryboard Storyboard="{StaticResource Storyboard2}"/>
            </EventTrigger>
        </Window.Triggers>
    
        <Grid>
            <Expander x:Name="expander" Margin="5" BorderBrush="Black" BorderThickness="1" HorizontalAlignment="Stretch" IsExpanded="False">
                <Expander.Header>
                    <StackPanel Width="195.313">
                        <Grid x:Name="grid" RenderTransformOrigin="0.5,0.5">
                            <Grid.RenderTransform>
                                <TransformGroup>
                                    <ScaleTransform/>
                                    <SkewTransform/>
                                    <RotateTransform/>
                                    <TranslateTransform/>
                                </TransformGroup>
                            </Grid.RenderTransform>
                            <TextBlock x:Name="textBlock" Margin="5" VerticalAlignment="Center" RenderTransformOrigin="0.5,0.5">
                                <TextBlock.RenderTransform>
                                    <TransformGroup>
                                        <ScaleTransform/>
                                        <SkewTransform/>
                                        <RotateTransform/>
                                        <TranslateTransform/>
                                    </TransformGroup>
                                </TextBlock.RenderTransform><Run Text="Hello World"/></TextBlock>
                            <Button x:Name="button" Padding="5" RenderTransformOrigin="0.5,0.5" Content="Button" Margin="93,5,5,5">
                                <Button.RenderTransform>
                                    <TransformGroup>
                                        <ScaleTransform/>
                                        <SkewTransform/>
                                        <RotateTransform/>
                                        <TranslateTransform/>
                                    </TransformGroup>
                                </Button.RenderTransform>
                            </Button>
                        </Grid>
                    </StackPanel>
    
    
                </Expander.Header>
                <StackPanel Orientation="Horizontal">
                    <Canvas Margin="5" Width="300" Background="Black" />
    
                    <StackPanel>
                        <StackPanel.Resources>
                            <Style TargetType="{x:Type RadioButton}">
                                <Setter Property="Margin" Value="5" />
                            </Style>
                        </StackPanel.Resources>
                        <RadioButton IsChecked="True" Content="Option 1"/>
                        <RadioButton Content="Option 2"/>
                        <RadioButton Content="Option 3"/>
                        <RadioButton Content="Option 4"/>
                    </StackPanel>
                </StackPanel>
            </Expander>
        </Grid>
