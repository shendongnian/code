    <ListView x:Name="lsvMenuItem" SelectionMode="Single">
                <ListView.ItemContainerStyle>
                    <Style TargetType="ListViewItem">
                        <Setter Property="DataContext" Value="{Binding}" />
                        <Setter Property="Height" Value="30" />
                        <Setter Property="HorizontalAlignment" Value="Stretch" />
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="ListViewItem">
                                    <Border Background="Transparent">
                                        <Button  x:Name="button" HorizontalAlignment="Left" Content="{Binding}" Foreground="Blue"
                                                 IsHitTestVisible="False" Width="50"/>
                                    </Border>
                                    <ControlTemplate.Triggers>
                                        <Trigger Property="IsSelected" Value="True">
                                            <Setter TargetName="button"  Property="Background" Value="Red"/>
                                        </Trigger>
                                    </ControlTemplate.Triggers>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </ListView.ItemContainerStyle>
                <ListView.ItemsPanel>
                    <ItemsPanelTemplate>
                        <StackPanel Orientation="Horizontal" />
                    </ItemsPanelTemplate>
                </ListView.ItemsPanel>
        
            </ListView>
