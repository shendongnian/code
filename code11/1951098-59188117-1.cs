    <Button>
     <Button.Triggers>
            <EventTrigger RoutedEvent="Button.Click">
              <BeginStoryboard>
                <Storyboard>
    				<DoubleAnimation BeginTime="0:0:0.0" Storyboard.TargetName="userFound" Storyboard.TargetProperty="(Card.Opacity)" From="0" To="1" Duration="0:0:0.5"/> //Fade in taking half a second  
    				<DoubleAnimation BeginTime="0:0:1.5" Storyboard.TargetName="userFound" Storyboard.TargetProperty="(Card.Opacity)" From="1" To="0" Duration="0:0:0.5"/>//Fade out takes half a second 
                </Storyboard>
              </BeginStoryboard>
            </EventTrigger>
     </Button.Triggers>
    <Button>
