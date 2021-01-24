<DataGrid DockPanel.Dock="Left" ScrollViewer.CanContentScroll="True" x:Name="TagSelection" Margin="5" CanUserAddRows="False" CanUserSortColumns="False" AutoGenerateColumns="False" materialDesign:DataGridAssist.CellPadding="5 5 5 5" materialDesign:DataGridAssist.ColumnHeaderPadding="5" IsEnabled="False">
    <DataGrid.Columns>
        <DataGridTextColumn Header="ID" IsReadOnly="True" Binding="{Binding TagID}" ElementStyle="{StaticResource centerAligned}" EditingElementStyle="{StaticResource MaterialDesignDataGridTextColumnEditingStyle}"/>
        <DataGridTextColumn Header="Address"  Binding="{Binding TagAddress}" ElementStyle="{StaticResource centerAligned}" EditingElementStyle="{StaticResource MaterialDesignDataGridTextColumnEditingStyle}"/>
        <DataGridComboBoxColumn x:Name="TagTypeCombo" EditingElementStyle="{StaticResource MaterialDesignDataGridComboBox}" Header="Tag Type" SelectedValueBinding="{Binding TagType}">
        </DataGridComboBoxColumn>
    </DataGrid.Columns>
</DataGrid>
Hope this helps those who will encounter this problem in the future.
