    <Window.Resources>
        <ControlTemplate x:Key="ButtonTemplate" TargetType="{x:Type Button}" >
            <Path Name="Border" Stroke="Black" Width="100" Height="100">
                <Path.Data>
                    <PathGeometry>
                        <PathFigure IsClosed="True" StartPoint="10 10" >
                            <ArcSegment Point="90 90" Size="85 85" IsLargeArc="false" SweepDirection="Clockwise" />
                            <LineSegment Point="60 90" ></LineSegment>
                            <ArcSegment Point="10 40" Size="55 55" IsLargeArc="false" SweepDirection="Counterclockwise" />
                            <LineSegment Point="10 10" ></LineSegment>
                        </PathFigure>
                    </PathGeometry>
                </Path.Data>
                <Path.Style>
                    <Style TargetType="{x:Type Path}">
                    <Setter Property="Fill" Value="Green"/>
                    <Style.Triggers>
                        <Trigger Property="IsMouseOver" Value="True">
                            <Setter Property="Fill" Value="Red"/>
                        </Trigger>
                    </Style.Triggers>
                    </Style>
                </Path.Style>
            </Path>
        </ControlTemplate>
    </Window.Resources>
    <Grid Margin="10px">
        <Viewbox>
            <Grid RenderTransformOrigin="0.5,0.5" Grid.IsSharedSizeScope="True">
                <Grid.RenderTransform>
                    <TransformGroup>
                        <RotateTransform Angle="45"/>
                        <TranslateTransform/>
                    </TransformGroup>
                </Grid.RenderTransform>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition SharedSizeGroup="A"/>
                    <ColumnDefinition SharedSizeGroup="A"/>
                </Grid.ColumnDefinitions>
                <Grid.RowDefinitions>
                    <RowDefinition SharedSizeGroup="A"/>
                    <RowDefinition SharedSizeGroup="A"/>
                </Grid.RowDefinitions>
                <Button Template="{StaticResource ButtonTemplate}" Grid.Column="0" Grid.Row="0" RenderTransformOrigin="0.5,0.5">
                    <Button.RenderTransform>
                        <RotateTransform Angle="270"/>
                    </Button.RenderTransform>
                </Button>
                <Button Template="{StaticResource ButtonTemplate}" Grid.Column="1" Grid.Row="0" RenderTransformOrigin="0.5,0.5">
                </Button>
                <Button Template="{StaticResource ButtonTemplate}" Grid.Column="0" Grid.Row="1" RenderTransformOrigin="0.5,0.5">
                    <Button.RenderTransform>
                        <RotateTransform Angle="180"/>
                    </Button.RenderTransform>
                </Button>
                <Button Template="{StaticResource ButtonTemplate}" Grid.Column="1" Grid.Row="1" RenderTransformOrigin="0.5,0.5">
                    <Button.RenderTransform>
                        <RotateTransform Angle="90"/>
                    </Button.RenderTransform>
                </Button>
            </Grid>
        </Viewbox>
    </Grid>
