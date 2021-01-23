    <Storyboard x:Key="animate">
        <ObjectAnimationUsingKeyFrames BeginTime="0:0:0" Storyboard.TargetProperty="Visibility">
            <DiscreteObjectKeyFrame KeyTime="0">
                <DiscreteObjectKeyFrame.Value>
                    <Visibility>Visible</Visibility>
                </DiscreteObjectKeyFrame.Value>
            </DiscreteObjectKeyFrame>
        </ObjectAnimationUsingKeyFrames>
        <DoubleAnimation BeginTime="0:0:0.0" Storyboard.TargetProperty="Opacity" From="0" To="1" Duration="0:0:0.2"/>
        <DoubleAnimation BeginTime="0:0:5.0" Storyboard.TargetProperty="Opacity" From="1" To="0" Duration="0:0:0.5"/>
        <ObjectAnimationUsingKeyFrames BeginTime="0:0:5.5" Storyboard.TargetProperty="Visibility">
            <DiscreteObjectKeyFrame KeyTime="0">
                <DiscreteObjectKeyFrame.Value>
                    <Visibility>Hidden</Visibility>
                </DiscreteObjectKeyFrame.Value>
            </DiscreteObjectKeyFrame>
        </ObjectAnimationUsingKeyFrames>
    </Storyboard>
