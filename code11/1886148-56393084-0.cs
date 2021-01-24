    <ComboBox x:Name="theComboBox" SelectionChanged="ComboBox_SelectionChanged">
        <ComboBox.ItemsSource>
            <CompositeCollection>
                <ComboBoxItem Content="Use Default Font"/>
                <CollectionContainer Collection="{Binding Source={x:Static onts.SystemFontFamilies}}"/>
            </CompositeCollection>
        </ComboBox.ItemsSource>
    </ComboBox>
    
    <TextBlock x:Name="myTextblock" Text="Text in selected font" FontFamily="{Binding ElementName=theComboBox, Path=SelectedItem}" />
