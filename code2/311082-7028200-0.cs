    <!-- No more target here! -->
    <Application.Resources>
        <Storyboard x:Key="SB_Height">
        	<DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(FrameworkElement.Height)"
        			Storyboard.TargetName="{DynamicResource AnimationTarget}">
        		<EasingDoubleKeyFrame KeyTime="0:0:1" Value="90">
        			<EasingDoubleKeyFrame.EasingFunction>
        				<CircleEase EasingMode="EaseOut" />
        			</EasingDoubleKeyFrame.EasingFunction>
        		</EasingDoubleKeyFrame>
        	</DoubleAnimationUsingKeyFrames>
        </Storyboard>
    </Application.Resources>
