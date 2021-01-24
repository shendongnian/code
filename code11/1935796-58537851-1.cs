    <VisualStateManager.VisualStateGroups>
                        <VisualStateGroup x:Name="CommonStates">
                            <VisualStateGroup.Transitions>
                                <VisualTransition GeneratedDuration="0:0:0.5">
                                    <VisualTransition.GeneratedEasingFunction>
                                        <CircleEase EasingMode="EaseOut" />
                                    </VisualTransition.GeneratedEasingFunction>
                                </VisualTransition>
                            </VisualStateGroup.Transitions>
                            <VisualState x:Name="Normal" />
                            <VisualState x:Name="MouseOver">
                                <Storyboard>
                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(Panel.Background)"
                                                                   Storyboard.TargetName="Rectangle">
                                        <DiscreteObjectKeyFrame KeyTime="0">
                                            <DiscreteObjectKeyFrame.Value>
                                                <SolidColorBrush Color="Orange" />
                                            </DiscreteObjectKeyFrame.Value>
                                        </DiscreteObjectKeyFrame>
                                    </ObjectAnimationUsingKeyFrames>
                                </Storyboard>
                            </VisualState>
                            <VisualState x:Name="Pressed" />
                            <VisualState x:Name="Disabled" />
                        </VisualStateGroup>
                    </VisualStateManager.VisualStateGroups>
