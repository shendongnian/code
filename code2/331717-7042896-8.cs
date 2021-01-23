    <ItemsControl ItemsSource="{Binding Problems}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <ItemsControl ItemsSource="{Binding ProblemSubList}">
                    <ItemsControl.ItemsPanel>
                        <ItemsPanelTemplate>
                            <StackPanel Orientation="Horizontal" />
                        </ItemsPanelTemplate>
                    </ItemsControl.ItemsPanel>
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <Rectangle Fill="Red" Height="20" Width="20" Margin="1,0">
                                <Rectangle.Style>
                                    <Style TargetType="{x:Type Rectangle}">
                                        <Setter Property="Fill" Value="Red" />
                                        <Style.Triggers>
                                            <DataTrigger Binding="{Binding IsCorrect}" Value="True">
                                                <Setter Property="Fill" Value="Blue" />
                                            </DataTrigger>
                                        </Style.Triggers>
                                    </Style>
                                </Rectangle.Style>
                            </Rectangle>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
            </DataTemplate>
         </ItemsControl.ItemTemplate>
         <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <StackPanel Background="Aqua" Margin="5" />
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
    </ItemsControl>
