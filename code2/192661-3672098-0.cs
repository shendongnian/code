    <ComboBox Height="45" HorizontalAlignment="Left" Margin="184,66,0,0" Name="ComboBox1" VerticalAlignment="Top" Width="216">
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <Label Content="{Binding FullName}" Width="150" />
            </DataTemplate>
        </ComboBox.ItemTemplate>
        <ComboBox.ItemContainerStyle>
            <Style TargetType="{x:Type ComboBoxItem}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type ComboBoxItem}">
                            <Border x:Name="Bd"
                                    BorderBrush="{TemplateBinding BorderBrush}"
                                    BorderThickness="{TemplateBinding BorderThickness}"
                                    Background="{TemplateBinding Background}">
                                <StackPanel Orientation="Horizontal">
                                    <ContentPresenter HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" 
                                                      VerticalAlignment="{TemplateBinding VerticalContentAlignment}" />
                                    <Label Content="{Binding Title}" Width="100"/>
                                    <Label Content="{Binding BranchName}" />
                                </StackPanel>
                            </Border>
                            <ControlTemplate.Triggers>
                                <Trigger Property="IsHighlighted" Value="True">
                                    <Setter TargetName="Bd" Property="Background" Value="{DynamicResource {x:Static SystemColors.HighlightBrushKey}}" />
                                    <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.HighlightTextBrushKey}}" />
                                </Trigger>
                                <Trigger Property="IsEnabled" Value="False">
                                    <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}" />
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </ComboBox.ItemContainerStyle>
    </ComboBox>
