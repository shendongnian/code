    <VisualStateGroup x:Name="FooterVisibilityStates">
        <VisualState x:Name="FooterFadeIn">
            <Storyboard>
                <DoubleAnimationUsingKeyFrames Storyboard.TargetName="PlaylistFooter" Storyboard.TargetProperty="Opacity">
                    <EasingDoubleKeyFrame KeyTime="0" Value="0" />
                    <EasingDoubleKeyFrame KeyTime="0:0:0.3" Value="1" />
                </DoubleAnimationUsingKeyFrames>
                <ObjectAnimationUsingKeyFrames Storyboard.TargetName="PlaylistFooter" Storyboard.TargetProperty="Visibility">
                    <DiscreteObjectKeyFrame KeyTime="0" Value="Collapsed"/>
                    <DiscreteObjectKeyFrame KeyTime="0:0:0.3" Value="Visibility" />
                </ObjectAnimationUsingKeyFrames>
                
            </Storyboard>
        </VisualState>
        <VisualState x:Name="FooterFadeOut">
            <Storyboard>
                <DoubleAnimationUsingKeyFrames Storyboard.TargetName="PlaylistFooter" Storyboard.TargetProperty="Opacity">
                    <EasingDoubleKeyFrame KeyTime="0" Value="1" />
                    <EasingDoubleKeyFrame KeyTime="0:0:0.4" Value="0" />
                </DoubleAnimationUsingKeyFrames>
                <ObjectAnimationUsingKeyFrames Storyboard.TargetName="PlaylistFooter" Storyboard.TargetProperty="Visibility">
                    <DiscreteObjectKeyFrame KeyTime="0" Value="Visible"/>
                    <DiscreteObjectKeyFrame KeyTime="0:0:0.4" Value="Collapsed" />
                </ObjectAnimationUsingKeyFrames>
                <ObjectAnimationUsingKeyFrames Storyboard.TargetName="PlaylistFooter" Storyboard.TargetProperty="IsHitTestVisible">
                    <DiscreteObjectKeyFrame KeyTime="0" Value="False" />
                </ObjectAnimationUsingKeyFrames>
            </Storyboard>
        </VisualState>
    </VisualStateGroup>
