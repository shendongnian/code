        <StackPanel>
            <StackPanel.Resources>
               <local:BooleanToVisibilityConverter
                      x:Key="BooleanToVisibilityConverter" />
               <FrameworkElement x:Key="ProxyElement"
                                 DataContext="{Binding}"/>
            </StackPanel.Resources>
            <ContentControl Visibility="Collapsed"
                        Content="{StaticResource ProxyElement}"/>
            <DataGrid AutoGenerateColumns="False">
                <DataGrid.Columns>
                    <DataGridTextColumn
                           Visibility="{Binding DataContext.IsTextColumnVisibile,
                                                Source={StaticResource ProxyElement},
                                                Converter={StaticResource
                                                    BooleanToVisibilityConverter}}"
                           Binding="{Binding Text}"/>
                </DataGrid.Columns>
            </DataGrid>
        </StackPanel> 
