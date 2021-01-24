    <Trigger Property="IsPressed" Value="True">
                    <Trigger.ExitActions>
                        <BeginStoryboard>
                            <Storyboard  AutoReverse="True" >
                                <ColorAnimation Storyboard.TargetProperty="(Button.Background).(SolidColorBrush.Color)" Duration="0:0:0"/>
                                <ColorAnimation Storyboard.TargetProperty="(Button.Background).(SolidColorBrush.Color)" To="Orange" Duration="0:0:0.50"/>
                            </Storyboard>
                        </BeginStoryboard>
                    </Trigger.ExitActions>
                </Trigger>
