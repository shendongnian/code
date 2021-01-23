    <Style x:Key="GridStyle1" TargetType="{x:Type Grid}">
			<Style.Resources>
				<Storyboard x:Key="StoryboardShow">
					<DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="{x:Null}">
						<EasingDoubleKeyFrame KeyTime="0" Value="0"/>
						<EasingDoubleKeyFrame KeyTime="0:0:1" Value="1"/>
					</DoubleAnimationUsingKeyFrames>
				</Storyboard>
				<Storyboard x:Key="StoryboardHide">
					<DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(UIElement.Opacity)" Storyboard.TargetName="{x:Null}">
						<SplineDoubleKeyFrame KeyTime="0" Value="1"/>
						<SplineDoubleKeyFrame KeyTime="0:0:1" Value="0"/>
					</DoubleAnimationUsingKeyFrames>
				</Storyboard>
			</Style.Resources>
			<Style.Triggers>
				<Trigger Property="Visibility" Value="Visible">
					<Trigger.ExitActions>
						<BeginStoryboard Storyboard="{StaticResource StoryboardHide}"/>
					</Trigger.ExitActions>
					<Trigger.EnterActions>
						<BeginStoryboard Storyboard="{StaticResource StoryboardShow}"/>
					</Trigger.EnterActions>
				</Trigger>
			</Style.Triggers>
		</Style>
