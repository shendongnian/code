    <ComboBox IsEditable="True" Name="comboWell" ItemsSource="{Binding }">
        <ComboBox.ItemContainerStyle>
            <Style TargetType="{x:Type ComboBoxItem}">
                <Setter Property="Content" Value="{Binding wellId}" />
                <Style.Triggers>
                    <DataTrigger Binding="{Binding wellId}" Value="(settings)">
                        <Setter Property="Content" Value="Customize..." />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ComboBox.ItemContainerStyle>
    </ComboBox>
