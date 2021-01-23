                       <Grid x:Name="grid" Background="Transparent" >
                        	<Grid.Triggers>
                                  <EventTrigger RoutedEvent="RadioButton.Loaded">
                                      <BeginStoryboard>
                        		<Storyboard AutoReverse="True" RepeatBehavior="Forever">
                        			<DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="HighlightedSprite">
                        				<EasingDoubleKeyFrame KeyTime="0:0:1" Value="0.495"/>
                        				<EasingDoubleKeyFrame KeyTime="0:0:2" Value="1"/>
                        			</DoubleAnimationUsingKeyFrames>
                        		</Storyboard>
                                      </BeginStoryboard>
                                  </EventTrigger>
                        	</Grid.Triggers>
