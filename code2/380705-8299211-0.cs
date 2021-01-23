    <Style TargetType="TextBlock">
      <Setter Property="Template">
        <Setter.Value>
          <ControlTemplate TargetType="TextBlock">
            <VisualStateManager.VisualStateGroups>
              <VisualStateGroup x:Name="VisualStateGroup">
                  <VisualStateGroup.Transitions>
                      <VisualTransition GeneratedDuration="0:0:1">
                          <ei:ExtendedVisualStateManager.TransitionEffect>
                              <ee:FadeTransitionEffect/>
                          </ei:ExtendedVisualStateManager.TransitionEffect>
                      </VisualTransition>
                  </VisualStateGroup.Transitions>
                  <VisualState x:Name="MySate">
                      <Storyboard>
                          <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(TextElement.Background).(SolidColorBrush.Color)" Storyboard.TargetName="contentPresenter">
                              <EasingColorKeyFrame KeyTime="0" Value="#FFF31515"/>
                          </ColorAnimationUsingKeyFrames>
                      </Storyboard>
                  </VisualState>
              </VisualStateGroup>
              </VisualStateManager.VisualStateGroups>
              <VisualStateManager.CustomVisualStateManager>
              <ei:ExtendedVisualStateManager/>
            </VisualStateManager.CustomVisualStateManager>
            
            <ContentPresenter x:Name="contentPresenter" />
          </ControlTemplate>
        </Setter.Value>
      </Setter>
    </Style>
