    <Style TargetType="Button" x:Key="MyButton">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="Button">
                    <Grid>
                        <VisualStateManager.VisualStateGroups>
                            <VisualStateGroup x:Name="CommonStates">
                                <VisualState x:Name="MouseOver">
                                    <Storyboard AutoReverse="True" RepeatBehavior="Forever">
                                        <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="Angle" Storyboard.TargetName="content">
                                            <EasingDoubleKeyFrame KeyTime="0" Value="0" />
                                            <EasingDoubleKeyFrame KeyTime="0:0:1" Value="10"/>
                                            <EasingDoubleKeyFrame KeyTime="0:0:2" Value="0"/>
                                            <EasingDoubleKeyFrame KeyTime="0:0:3" Value="-10"/>
                                            <EasingDoubleKeyFrame KeyTime="0:0:4" Value="0"/>
                                        </DoubleAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                            </VisualStateGroup>
                        </VisualStateManager.VisualStateGroups>
                        <ContentPresenter Content="{TemplateBinding Content}">
                            <ContentPresenter.RenderTransform>
                                <TransformGroup>
                                    <RotateTransform CenterX="0.5" CenterY="0.5" Angle="0" x:Name="content"/>
                                </TransformGroup>
                            </ContentPresenter.RenderTransform>
                                    
                        </ContentPresenter>
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
