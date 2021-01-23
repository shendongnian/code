    <ComboBox Name="comboWell" ItemsSource="{Binding }">
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <ContentControl>
                    <ContentControl.Style>
                        <Style TargetType="{x:Type ContentControl}">
                            <Setter Property="Content" Value="{Binding wellId}" />
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding wellId}" Value="(settings)">
                                    <Setter Property="Content" Value="Customize..." />
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </ContentControl.Style>
                </ContentControl>
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>
