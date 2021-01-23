    <ControlTemplate TargetType="Button">
        <Grid x:Name="Root">
            <VisualStateManager.VisualStateGroups>
                <VisualStateGroup x:Name="CommonStates">
                    <VisualStateGroup.Transitions>
                        <VisualTransition GeneratedDuration="0:0:0.1" />
                        <VisualTransition To="Pressed" />
                        <VisualTransition From="Pressed" />
                    </VisualStateGroup.Transitions>
                    <VisualState x:Name="Normal" />
                    <VisualState x:Name="MouseOver">
                        <Storyboard>
                            <DoubleAnimation Duration="0" Storyboard.TargetName="PressedElement" Storyboard.TargetProperty="(FrameworkElement.Opacity)" To="0" />
                            <DoubleAnimation Duration="0" Storyboard.TargetName="MouseOverElement" Storyboard.TargetProperty="(FrameworkElement.Opacity)" To="1" />
                        </Storyboard>
                    </VisualState>
                    <VisualState x:Name="Pressed">
                        <Storyboard>
                            <DoubleAnimation Duration="0" Storyboard.TargetName="NormalElement" Storyboard.TargetProperty="(FrameworkElement.Opacity)" To="0.25" />
                            <DoubleAnimation Duration="0" Storyboard.TargetName="PressedElement" Storyboard.TargetProperty="(FrameworkElement.Opacity)" To="1" />
