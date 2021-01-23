    <Style TargetType="Button" x:Key="MyStyle">
                <Style.Resources>
                    <Storyboard x:Key="MyGetFocusAnimation">
                        <DoubleAnimation Storyboard.TargetProperty="Height"
                                         To="50"
                                         Duration="0:0:.3" />
                    </Storyboard>
                    <Storyboard x:Key="MyLoseFocusAnimation">
                        <DoubleAnimation Storyboard.TargetProperty="Height"
                                         To="30"
                                         Duration="0:0:.3" />
                    </Storyboard>
                </Style.Resources>
                <Style.Triggers>
                    <Trigger Property="IsMouseOver"
                             Value="True">
                        <Trigger.EnterActions>
                            <BeginStoryboard Storyboard="{StaticResource MyGetFocusAnimation}" />
                        </Trigger.EnterActions>
                        <Trigger.ExitActions>
                            <BeginStoryboard Storyboard="{StaticResource MyLoseFocusAnimation}" />
                        </Trigger.ExitActions>
                    </Trigger>
                    <Trigger Property="IsKeyboardFocusWithin"
                             Value="True">
                        <Trigger.EnterActions>
                            <BeginStoryboard Storyboard="{StaticResource MyGetFocusAnimation}" />
                        </Trigger.EnterActions>
                        <Trigger.ExitActions>
                            <BeginStoryboard Storyboard="{StaticResource MyLoseFocusAnimation}" />
                        </Trigger.ExitActions>
                    </Trigger>
                </Style.Triggers>
            </Style>
