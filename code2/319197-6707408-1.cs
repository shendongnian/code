    <Style x:Key="AutoCompleteBoxStyle1" TargetType="sdk:AutoCompleteBox">
                    <Setter Property="IsTabStop" Value="False"/>
                    <Setter Property="Padding" Value="2"/>
                    <Setter Property="BorderThickness" Value="1"/>
                    <Setter Property="BorderBrush">
                        <Setter.Value>
                            <LinearGradientBrush EndPoint="0.5,1" StartPoint="0.5,0">
                                <GradientStop Color="#FFA3AEB9" Offset="0"/>
                                <GradientStop Color="#FF8399A9" Offset="0.375"/>
                                <GradientStop Color="#FF718597" Offset="0.375"/>
                                <GradientStop Color="#FF617584" Offset="1"/>
                            </LinearGradientBrush>
                        </Setter.Value>
                    </Setter>
                    <Setter Property="Background" Value="#FFFFFFFF"/>
                    <Setter Property="Foreground" Value="#FF000000"/>
                    <Setter Property="MinWidth" Value="45"/>
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="sdk:AutoCompleteBox">
                                <Grid Opacity="{TemplateBinding Opacity}">
                                    <VisualStateManager.VisualStateGroups>
                                        <VisualStateGroup x:Name="PopupStates">
                                            <VisualStateGroup.Transitions>
                                                <VisualTransition GeneratedDuration="0:0:0.1" To="PopupOpened"/>
                                                <VisualTransition GeneratedDuration="0:0:0.2" To="PopupClosed"/>
                                            </VisualStateGroup.Transitions>
                                            <VisualState x:Name="PopupOpened">
                                                <Storyboard>
                                                    <DoubleAnimation To="1.0" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="PopupBorder"/>
                                                </Storyboard>
                                            </VisualState>
                                            <VisualState x:Name="PopupClosed">
                                                <Storyboard>
                                                    <DoubleAnimation To="0.0" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="PopupBorder"/>
                                                </Storyboard>
                                            </VisualState>
                                        </VisualStateGroup>
                                        <VisualStateGroup x:Name="ValidationStates">
                                            <VisualState x:Name="Valid"/>
                                            <VisualState x:Name="InvalidUnfocused">
                                                <Storyboard>
                                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility" Storyboard.TargetName="ValidationErrorElement">
                                                        <DiscreteObjectKeyFrame KeyTime="0">
                                                            <DiscreteObjectKeyFrame.Value>
                                                                <Visibility>Visible</Visibility>
                                                            </DiscreteObjectKeyFrame.Value>
                                                        </DiscreteObjectKeyFrame>
                                                    </ObjectAnimationUsingKeyFrames>
                                                </Storyboard>
                                            </VisualState>
                                            <VisualState x:Name="InvalidFocused">
                                                <Storyboard>
                                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility" Storyboard.TargetName="ValidationErrorElement">
                                                        <DiscreteObjectKeyFrame KeyTime="0">
                                                            <DiscreteObjectKeyFrame.Value>
                                                                <Visibility>Visible</Visibility>
                                                            </DiscreteObjectKeyFrame.Value>
                                                        </DiscreteObjectKeyFrame>
                                                    </ObjectAnimationUsingKeyFrames>
                                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="IsOpen" Storyboard.TargetName="validationTooltip">
                                                        <DiscreteObjectKeyFrame KeyTime="0">
                                                            <DiscreteObjectKeyFrame.Value>
                                                                <System:Boolean>True</System:Boolean>
                                                            </DiscreteObjectKeyFrame.Value>
                                                        </DiscreteObjectKeyFrame>
                                                    </ObjectAnimationUsingKeyFrames>
                                                </Storyboard>
                                            </VisualState>
                                        </VisualStateGroup>
                                    </VisualStateManager.VisualStateGroups>
                                    <TextBox x:Name="Text" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" Foreground="{TemplateBinding Foreground}" IsTabStop="True" Margin="0" Padding="{TemplateBinding Padding}" Style="{TemplateBinding TextBoxStyle}" SelectionChanged="Text_SelectionChanged"/>
                                    <Border x:Name="ValidationErrorElement" BorderBrush="#FFDB000C" BorderThickness="1" CornerRadius="1" Visibility="Collapsed">
                                        <ToolTipService.ToolTip>
                                            <ToolTip x:Name="validationTooltip" DataContext="{Binding RelativeSource={RelativeSource TemplatedParent}}" Placement="Right" PlacementTarget="{Binding RelativeSource={RelativeSource TemplatedParent}}" Template="{StaticResource CommonValidationToolTipTemplate}">
                                                <ToolTip.Triggers>
                                                    <EventTrigger RoutedEvent="Canvas.Loaded">
                                                        <BeginStoryboard>
                                                            <Storyboard>
                                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="IsHitTestVisible" Storyboard.TargetName="validationTooltip">
                                                                    <DiscreteObjectKeyFrame KeyTime="0">
                                                                        <DiscreteObjectKeyFrame.Value>
                                                                            <System:Boolean>true</System:Boolean>
                                                                        </DiscreteObjectKeyFrame.Value>
                                                                    </DiscreteObjectKeyFrame>
                                                                </ObjectAnimationUsingKeyFrames>
                                                            </Storyboard>
                                                        </BeginStoryboard>
                                                    </EventTrigger>
                                                </ToolTip.Triggers>
                                            </ToolTip>
                                        </ToolTipService.ToolTip>
                                        <Grid Background="Transparent" HorizontalAlignment="Right" Height="12" Margin="1,-4,-4,0" VerticalAlignment="Top" Width="12">
                                            <Path Data="M 1,0 L6,0 A 2,2 90 0 1 8,2 L8,7 z" Fill="#FFDC000C" Margin="1,3,0,0"/>
                                            <Path Data="M 0,0 L2,0 L 8,6 L8,8" Fill="#ffffff" Margin="1,3,0,0"/>
                                        </Grid>
                                    </Border>
                                    <Popup x:Name="Popup">
                                        <Grid Opacity="{TemplateBinding Opacity}">
                                            <Border x:Name="PopupBorder" BorderThickness="0" Background="#11000000" HorizontalAlignment="Stretch" Opacity="0">
                                                <Border.RenderTransform>
                                                    <TranslateTransform X="1" Y="1"/>
                                                </Border.RenderTransform>
                                                <Border BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" CornerRadius="0" HorizontalAlignment="Stretch" Opacity="1.0" Padding="0">
                                                    <Border.Background>
                                                        <LinearGradientBrush EndPoint="0.5,1" StartPoint="0.5,0">
                                                            <GradientStop Color="#FFDDDDDD" Offset="0"/>
                                                            <GradientStop Color="#AADDDDDD" Offset="1"/>
                                                        </LinearGradientBrush>
                                                    </Border.Background>
                                                    <Border.RenderTransform>
                                                        <TransformGroup>
                                                            <TranslateTransform X="-1" Y="-1"/>
                                                        </TransformGroup>
                                                    </Border.RenderTransform>
                                                    <ListBox x:Name="Selector" BorderThickness="0" Background="{TemplateBinding Background}" Foreground="{TemplateBinding Foreground}" ScrollViewer.HorizontalScrollBarVisibility="Auto" ItemTemplate="{TemplateBinding ItemTemplate}" ItemContainerStyle="{TemplateBinding ItemContainerStyle}" ScrollViewer.VerticalScrollBarVisibility="Auto"/>
                                                </Border>
                                            </Border>
                                        </Grid>
                                    </Popup>
                                </Grid>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
