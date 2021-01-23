    <Application.Resources>
            <ResourceDictionary>
                <Storyboard x:Key="ShowMenuAnimationKey">
                    <DoubleAnimation
                                Storyboard.TargetName="{Binding}" //this is important
                                Storyboard.TargetProperty="(Canvas.Left)"
                                From="0" To="400" Duration="0:0:1">
                    </DoubleAnimation>
                </Storyboard>
            </ResourceDictionary>
        </Application.Resources>
