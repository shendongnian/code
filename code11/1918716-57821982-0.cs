    <Window.Resources>
        <Storyboard x:Key="storyboard2">
            <DoubleAnimation Storyboard.TargetProperty="RenderTransform.ScaleX"
                To="4" From="1" AutoReverse="True"
                RepeatBehavior="Forever" Duration="00:00:10"/>
            <DoubleAnimation  Storyboard.TargetProperty="RenderTransform.ScaleY"
                From="4" To="1" AutoReverse="True"
                RepeatBehavior="Forever" Duration="00:00:10"/>
        </Storyboard>
    </Window.Resources>
    <Rectangle Width="100" Height="100" Fill="Red">
        <Rectangle.Style>
            <Style TargetType="Rectangle">
                <Setter Property="RenderTransform">
                    <Setter.Value>
                        <ScaleTransform/>
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding RunAnimation}" Value="True">
                        <DataTrigger.EnterActions>
                            <BeginStoryboard x:Name="BeginScaleFrom"
                                Storyboard="{StaticResource storyboard2}"/>
                        </DataTrigger.EnterActions>
                        <DataTrigger.ExitActions>
                            <StopStoryboard BeginStoryboardName="BeginScaleFrom"/>
                        </DataTrigger.ExitActions>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Rectangle.Style>
    </Rectangle>
