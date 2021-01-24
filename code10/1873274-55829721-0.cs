    <ItemsControl ItemsSource="{Binding LDLTracks}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Canvas/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <ItemsControl ItemsSource="{Binding Coordinates}">
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <Line X1="{Binding X1}" Y1="{Binding Y1}" X2="{Binding X2}" Y2="{Binding Y2}"
                                  Stroke="{Binding LineColor}" StrokeThickness="5">
                                <Line.InputBindings>
                                    <MouseBinding Gesture="LeftClick" Command="{Binding FooCommand}"/>
                                </Line.InputBindings>
                            </Line>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
