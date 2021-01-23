    <ComboBox SelectedValuePath="Tag" SelectedValue="{Binding IsActive, Mode=TwoWay}">
        <ComboBoxItem Content="No">
            <ComboBoxItem.Tag>
                <sys:Boolean>False</sys:Boolean>
            </ComboBoxItem.Tag>
        </ComboBoxItem>
        <ComboBoxItem Content="Yes">
            <ComboBoxItem.Tag>
                <sys:Boolean>True</sys:Boolean>
            </ComboBoxItem.Tag>
        </ComboBoxItem>
    </ComboBox>
