    <Style TargetType="{x:Type FrameworkElement}" x:Key="animateFadeOut">
             <Style.Triggers>
                <Trigger Property="Visibility" Value="Visible">
                   <Trigger.EnterActions>
                      <BeginStoryboard Name="MyFadeEffect">
                         <Storyboard>
                            <DoubleAnimation BeginTime="0:0:5.0" Storyboard.TargetProperty="Opacity"
                             From="1.0" To="0.0" Duration="0:0:0.5"/>
                         </Storyboard>
                      </BeginStoryboard>
                   </Trigger.EnterActions>
                   <Trigger.ExitActions>
                      <StopStoryboard BeginStoryboardName="MyFadeEffect"/>
                   </Trigger.ExitActions>
                </Trigger>
             </Style.Triggers>
          </Style>
