    <DataGridComboBoxColumn Padding="0,0,0,5" x:Name="itemname_list" SelectedItem="{Binding pitemnames, UpdateSourceTrigger=PropertyChanged}" ItemsSource="{Binding pitemname}"  IsEditable="True" IsTextSearchEnabled="False" KeyUp="itemname_list_KeyUp">
        <DataGridComboBoxColumn.EditingElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="IsDropDownOpen" Value="True" />
            </Style>
        </DataGridComboBoxColumn.EditingElementStyle>
    </DataGridComboBoxColumn>
