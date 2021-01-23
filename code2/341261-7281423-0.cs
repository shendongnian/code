    <Trigger Property="IsSelected" Value="false">
    	<Trigger.EnterActions>
    		<StopStoryboard BeginStoryboardName="start"/>
    		<BeginStoryboard Name="end" Storyboard="{StaticResource endHeaderEdit}"/>
    	</Trigger.EnterActions>
        <Setter TargetName="tabDockPanel" Property="Background" Value="#FFC9C7BA" />
    </Trigger>
    <EventTrigger RoutedEvent="Control.MouseDoubleClick">
        <BeginStoryboard Name="start" Storyboard="{StaticResource startHeaderEdit}"/>
    </EventTrigger>
