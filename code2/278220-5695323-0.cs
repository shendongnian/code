    <Style TargetType="{x:Type TextBox}">
        <Style.Triggers>
            <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                    <Condition Binding="{Binding IsFocused, RelativeSource={RelativeSource Self}}" Value="False"/>
                    <Condition Binding="{Binding Text, RelativeSource={RelativeSource Self}}" Value=""/>
                </MultiDataTrigger.Conditions>
                <MultiDataTrigger.EnterActions>
                    <BeginStoryboard>
                        <Storyboard>
                            <StringAnimationUsingKeyFrames Storyboard.TargetProperty="Text">
                                <DiscreteStringKeyFrame KeyTime="0:0:0" Value="000000"/>
                            </StringAnimationUsingKeyFrames>
                        </Storyboard>
                    </BeginStoryboard>
                </MultiDataTrigger.EnterActions>
            </MultiDataTrigger>
            <MultiDataTrigger>
                <MultiDataTrigger.Conditions>
                    <Condition Binding="{Binding IsFocused, RelativeSource={RelativeSource Self}}" Value="True"/>
                    <Condition Binding="{Binding Text, RelativeSource={RelativeSource Self}}" Value="000000"/>
                </MultiDataTrigger.Conditions>
                <MultiDataTrigger.EnterActions>
                    <BeginStoryboard>
                        <Storyboard>
                            <StringAnimationUsingKeyFrames Storyboard.TargetProperty="Text">
                                <DiscreteStringKeyFrame KeyTime="0:0:0" Value=""/>
                            </StringAnimationUsingKeyFrames>
                        </Storyboard>
                    </BeginStoryboard>
                </MultiDataTrigger.EnterActions>
            </MultiDataTrigger>
            <Trigger Property="Text" Value="000000">
                <Setter Property="Foreground" Value="Silver"/>
            </Trigger>
        </Style.Triggers>
        <!-- If (Text != "000000") Foreground = Brushes.Black -->
        <Setter Property="Foreground" Value="Black"/>
    </Style>
