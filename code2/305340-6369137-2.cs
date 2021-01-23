    <ColorAnimationUsingKeyFrames Storyboard.TargetName="ellipse0" Storyboard.TargetProperty="(Shape.Fill).(SolidColorBrush.Color)">
    	<SplineColorKeyFrame KeyTime="00:00:00.0" Value="{StaticResource FilledColor}"/>
    	<SplineColorKeyFrame KeyTime="00:00:01.6" Value="{StaticResource UnfilledColor}"/>
    </ColorAnimationUsingKeyFrames>
        <DoubleAnimationUsingKeyFrames Storyboard.TargetName="ellipse0" Storyboard.TargetProperty="Width" >
    	<DoubleAnimationUsingKeyFrames.KeyFrames>
    		<SplineDoubleKeyFrame  KeyTime="00:00:00.0" Value="15" />
    		<SplineDoubleKeyFrame  KeyTime="00:00:01.0" Value="12" />
    		<SplineDoubleKeyFrame  KeyTime="00:00:01.6" Value="0" />
    	</DoubleAnimationUsingKeyFrames.KeyFrames>
    </DoubleAnimationUsingKeyFrames>
    <DoubleAnimationUsingKeyFrames Storyboard.TargetName="ellipse0" Storyboard.TargetProperty="Height" >
    	<DoubleAnimationUsingKeyFrames.KeyFrames>
    		<SplineDoubleKeyFrame  KeyTime="00:00:00.0" Value="15" />
    		<SplineDoubleKeyFrame  KeyTime="00:00:01.0" Value="12" />
    		<SplineDoubleKeyFrame  KeyTime="00:00:01.6" Value="0" />
    	</DoubleAnimationUsingKeyFrames.KeyFrames>
    </DoubleAnimationUsingKeyFrames>
