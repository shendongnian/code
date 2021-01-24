     <DataGridTemplateColumn  Header="Meter" Width="Auto" IsReadOnly="True">
            <DataGridTemplateColumn.CellTemplate>
                <DataTemplate>
                    <ComboBox   Style="{StaticResource MaterialDesignDataGridComboBox}" 
                                Foreground="{DynamicResource MaterialDesignBody}"
                                ItemsSource="{Binding PotentialMeters, Mode=OneWay}" 
                                DisplayMemberPath="Name"
                                Text="{Binding Segment.Meter.Name, Mode=OneWay}" 
                                SelectedItem="{Binding Segment.Meter}">
                    </ComboBox>
                </DataTemplate>
            </DataGridTemplateColumn.CellTemplate>
        </DataGridTemplateColumn>
