    <ComboBox SelectedValuePath="Tag" SelectedValue="{Binding YourIntProperty, Mode=TwoWay}">
        <ComboBoxItem Content="First choice">
            <ComboBoxItem.Tag>
                <sys:Int32>0</sys:Int32>
            </ComboBoxItem.Tag>
        </ComboBoxItem>
        <ComboBoxItem Content="Second choice">
            <ComboBoxItem.Tag>
                <sys:Int32>1</sys:Int32>
            </ComboBoxItem.Tag>
        </ComboBoxItem>
        <ComboBoxItem Content="Third choice">
            <ComboBoxItem.Tag>
                <sys:Int32>2</sys:Int32>
            </ComboBoxItem.Tag>
        </ComboBoxItem>
    </ComboBox>
