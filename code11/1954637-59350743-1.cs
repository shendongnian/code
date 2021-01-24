<Style TargetType="{x:Type StackPanel}">
    <Style.Setters>
        <Setter Property="Background">
            <Setter.Value>
                <DrawingBrush />
                <!--A default drawing brush-->
            </Setter.Value>
        </Setter>
    </Style.Setters>
    <Style.Triggers>
        <DataTrigger Binding="{Binding Checked}"
                     Value="True">
            <Setter Property="Background">
                <Setter.Value>
                    <DrawingBrush x:Name="errorBrush"
                                  TileMode="Tile"
                                  Viewport="0 0 1 1"
                                  ViewportUnits="Absolute">
                        <DrawingBrush.RelativeTransform>
                            <RotateTransform Angle="45" />
                        </DrawingBrush.RelativeTransform>
                        <DrawingBrush.Drawing>
                            <GeometryDrawing>
                                <GeometryDrawing.Geometry>
                                    <LineGeometry StartPoint="0,0"
                                                  EndPoint="4,2" />
                                </GeometryDrawing.Geometry>
                                <GeometryDrawing.Pen>
                                    <Pen Brush="Red"
                                         Thickness="4" />
                                </GeometryDrawing.Pen>
                            </GeometryDrawing>
                        </DrawingBrush.Drawing>
                    </DrawingBrush>
                </Setter.Value>
            </Setter>
            <DataTrigger.ExitActions>
                <BeginStoryboard>
                    <Storyboard>
                        <!-- Storyboard.TargetProperty = "opacity" throws no error -->
                        <DoubleAnimationUsingKeyFrames FillBehavior="Stop"
                                                       Storyboard.TargetProperty="Background.Opacity"
                                                       Duration="0:0:1">
                            <LinearDoubleKeyFrame KeyTime="0:0:0.0"
                                                  Value="0.2" />
                            <LinearDoubleKeyFrame KeyTime="0:0:0.3"
                                                  Value="0.3" />
                            <LinearDoubleKeyFrame KeyTime="0:0:0.5"
                                                  Value="0.8" />
                            <LinearDoubleKeyFrame KeyTime="0:0:1"
                                                  Value="1" />
                        </DoubleAnimationUsingKeyFrames>
                    </Storyboard>
                </BeginStoryboard>
            </DataTrigger.ExitActions>
        </DataTrigger>
    </Style.Triggers>
</Style>
**UPDATED ANSWER**
This is how I managed to get your updated question with HasError to work. Please give this a try:
<ListView ItemsSource="{Binding bsources}">
    <ListView.ItemTemplate>
        <DataTemplate>
            <DataTemplate.Resources>
                <DrawingBrush x:Key="DB" Opacity="0" TileMode="Tile" Viewport="0 0 1 1" ViewportUnits="Absolute">
                    <DrawingBrush.RelativeTransform>
                        <RotateTransform Angle="45" />
                    </DrawingBrush.RelativeTransform>
                    <DrawingBrush.Drawing>
                        <GeometryDrawing>
                            <GeometryDrawing.Geometry>
                                <LineGeometry StartPoint="0,0" EndPoint="4,2" />
                            </GeometryDrawing.Geometry>
                            <GeometryDrawing.Pen>
                                <Pen Brush="Red" Thickness="4" />
                            </GeometryDrawing.Pen>
                        </GeometryDrawing>
                    </DrawingBrush.Drawing>
                </DrawingBrush>
            </DataTemplate.Resources>
            <StackPanel Orientation="Horizontal">
                <StackPanel.Style>
                    <Style TargetType="{x:Type StackPanel}">
                        <Style.Setters>
                            <Setter Property="Background" Value="{StaticResource DB}"/>
                        </Style.Setters>
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding HasError}" Value="True">
                                <DataTrigger.EnterActions>
                                    <BeginStoryboard>
                                        <Storyboard>
                                            <DoubleAnimationUsingKeyFrames
                                                FillBehavior="HoldEnd"
                                                Storyboard.TargetProperty="Background.Opacity"
                                                Duration="0:0:1">
                                                <LinearDoubleKeyFrame KeyTime="0:0:0.0" Value="0.2" />
                                                <LinearDoubleKeyFrame KeyTime="0:0:0.3" Value="0.3" />
                                                <LinearDoubleKeyFrame KeyTime="0:0:0.5" Value="0.8" />
                                                <LinearDoubleKeyFrame KeyTime="0:0:1" Value="1" />
                                            </DoubleAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </BeginStoryboard>
                                </DataTrigger.EnterActions>
                            </DataTrigger>
                            <DataTrigger Binding="{Binding HasError}" Value="false">
                                <Setter Property="Background">
                                    <Setter.Value>
                                        <DrawingBrush Opacity="0" />
                                    </Setter.Value>
                                </Setter>
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </StackPanel.Style>
                <CheckBox IsChecked="{Binding Checked}" />
                <TextBlock Margin="20,0,0,0" Text="{Binding Name}" />
                <TextBlock Margin="20,0,0,0" Text="{Binding Address}" />
            </StackPanel>
        </DataTemplate>
    </ListView.ItemTemplate>
</ListView>
