    <StackPanel>
        <ListView ItemsSource="{Binding Systems}" >
            <ListView.ItemTemplate>
                <DataTemplate>
                    <CheckBox Content="{Binding TemplateName}" IsChecked="{Binding 
                        IsSystemChecked, UpdateSourceTrigger=PropertyChanged}"/>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    
        <ComboBox ItemsSource="{Binding Systems}" DisplayMemberPath="TemplateName" >
            <ComboBox.Style>
                <Style TargetType="ComboBox">
                    <Setter Property="ItemContainerStyle">
                        <Setter.Value>
                            <Style TargetType="ComboBoxItem" BasedOn="{StaticResource {x:Type ComboBoxItem}}">
                                <Style.Triggers>
                                    <DataTrigger Binding="{Binding IsSystemChecked}" Value="False">
                                        <Setter Property="Visibility" Value="Collapsed" />
                                    </DataTrigger>
                                </Style.Triggers>
                            </Style>
                        </Setter.Value>
                    </Setter>
                </Style>
            </ComboBox.Style>
        </ComboBox>
    </StackPanel>
