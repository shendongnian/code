    <CheckBox x:Name="chk" Content="Click Me" />
    <ComboBox ItemsSource="{Binding}">
        <ComboBox.Style>
            <Style TargetType="ComboBox">
                <Setter Property="ItemTemplate">
                    <Setter.Value>
                        <DataTemplate>
                            <StackPanel>
                                <TextBlock Text="{Binding Name}" />
                            </StackPanel>
                        </DataTemplate>
                    </Setter.Value>
                </Setter>
                
                <Style.Triggers>
                    <DataTrigger Binding="{Binding IsChecked,ElementName=chk}" Value="True">
                        <Setter Property="ItemTemplate">
                            <Setter.Value>
                                <DataTemplate>
                                    <StackPanel Orientation="Horizontal">
                                        <TextBlock Text="{Binding ID}" />
                                        <TextBlock Text=": " />
                                        <TextBlock Text="{Binding Name}" />
                                    </StackPanel>
                                </DataTemplate>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ComboBox.Style>
    </ComboBox>
