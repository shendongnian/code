      <UserControl.Resources>
            <DataTemplate x:Key="DataTemplate1">
                <StackPanel>
                    <TextBlock Text="{Binding message}"/>
                </StackPanel>
            </DataTemplate>
            <DataTemplate x:Key="DataTemplate2">
                <StackPanel>
                    <TextBlock Text="{Binding message}" FontWeight="Bold"/>
                </StackPanel>
            </DataTemplate>
    
            <Style TargetType="ListBoxItem">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="ListBoxItem">
                            <Grid Background="{Binding Path=type}">
                                <VisualStateManager.VisualStateGroups>
                                    <VisualStateGroup x:Name="CommonStates">
                                        <VisualState x:Name="Normal"/>
                                        <VisualState x:Name="MouseOver">
                                            <Storyboard>
                                                <DoubleAnimation Duration="0" To=".35" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="fillColor"/>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="Disabled">
                                            <Storyboard>
                                                <DoubleAnimation Duration="0" To=".55" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="contentPresenter1"/>
                                            </Storyboard>
                                        </VisualState>
                                    </VisualStateGroup>
                                    <VisualStateGroup x:Name="SelectionStates">
                                        <VisualState x:Name="Unselected"/>
                                        <VisualState x:Name="Selected">
                                            <Storyboard>
                                                <DoubleAnimation Duration="0" To=".75" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="fillColor2"/>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)" Storyboard.TargetName="contentPresenter1">
                                                    <DiscreteObjectKeyFrame KeyTime="0">
                                                        <DiscreteObjectKeyFrame.Value>
                                                            <Visibility>Collapsed</Visibility>
                                                        </DiscreteObjectKeyFrame.Value>
                                                    </DiscreteObjectKeyFrame>
                                                </ObjectAnimationUsingKeyFrames>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Visibility)" Storyboard.TargetName="contentPresenter2">
                                                    <DiscreteObjectKeyFrame KeyTime="0">
                                                        <DiscreteObjectKeyFrame.Value>
                                                            <Visibility>Visible</Visibility>
                                                        </DiscreteObjectKeyFrame.Value>
                                                    </DiscreteObjectKeyFrame>
                                                </ObjectAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                    </VisualStateGroup>
                                    <VisualStateGroup x:Name="FocusStates">
                                        <VisualState x:Name="Focused">
                                            <Storyboard>
                                                <ObjectAnimationUsingKeyFrames Duration="0" Storyboard.TargetProperty="Visibility" Storyboard.TargetName="FocusVisualElement">
                                                    <DiscreteObjectKeyFrame KeyTime="0">
                                                        <DiscreteObjectKeyFrame.Value>
                                                            <Visibility>Visible</Visibility>
                                                        </DiscreteObjectKeyFrame.Value>
                                                    </DiscreteObjectKeyFrame>
                                                </ObjectAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="Unfocused"/>
                                    </VisualStateGroup>
                                </VisualStateManager.VisualStateGroups>
                                <Rectangle x:Name="fillColor" Fill="#FFBADDE9" IsHitTestVisible="False" Opacity="0" RadiusY="1" RadiusX="1"/>
                                <Rectangle x:Name="fillColor2" Fill="#FFBADDE9" IsHitTestVisible="False" Opacity="0" RadiusY="1" RadiusX="1"/>
                                <ContentPresenter x:Name="contentPresenter1" ContentTemplate="{StaticResource DataTemplate1}" Content="{TemplateBinding Content}" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" Margin="{TemplateBinding Padding}"/>
                                <ContentPresenter x:Name="contentPresenter2" ContentTemplate="{StaticResource DataTemplate2}" Content="{TemplateBinding Content}" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" Margin="3,3,0,3" Visibility="Collapsed"/>
                                <Rectangle x:Name="FocusVisualElement" RadiusY="1" RadiusX="1" Stroke="#FF6DBDD1" StrokeThickness="1" Visibility="Collapsed"/>
                                <ListBox HorizontalAlignment="Left" Height="4" Margin="-90,0,0,-163" VerticalAlignment="Bottom" Width="31"/>
                            </Grid>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
    
            </Style>
    
        </UserControl.Resources>
