	<Grid>
        <Grid.Resources>
            <Style x:Key="ButtonStyle1" TargetType="{x:Type Button}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type Button}">
                            <Image x:Name="image" Height="100" Width="Auto" Source="http://thecybershadow.net/misc/stackoverflow.png" Margin="0,0,-25,0">
                                <Image.Effect>
                                    <DropShadowEffect ShadowDepth="0"/>
                                </Image.Effect>
                                <VisualStateManager.VisualStateGroups>
                                    <VisualStateGroup x:Name="CommonStates">
                                        <VisualStateGroup.Transitions>
                                            <VisualTransition GeneratedDuration="0:0:0.5"/>
                                        </VisualStateGroup.Transitions>
                                        <VisualState x:Name="Normal"/>
                                        <VisualState x:Name="MouseOver">
                                            <Storyboard>
                                                <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Effect).(DropShadowEffect.ShadowDepth)" Storyboard.TargetName="image">
                                                    <EasingDoubleKeyFrame KeyTime="0" Value="15"/>
                                                </DoubleAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="Pressed"/>
                                        <VisualState x:Name="Disabled"/>
                                    </VisualStateGroup>
                                </VisualStateManager.VisualStateGroups>
                            </Image>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </Grid.Resources>
		<Button Style="{StaticResource ButtonStyle1}"/>
	</Grid>
