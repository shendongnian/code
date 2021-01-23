    <DataTemplate x:Key="TaskSelectedTemplate">
        <Grid Margin="4">
            ...
            <Border Grid.Row="0" Grid.Column="0" Grid.RowSpan="4" Margin="0 0 4 0"
                    BorderThickness="0" 
                    CornerRadius="2">
                <Border.Background>
                    <MultiBinding Converter="{StaticResource ActiveToColor}">
                        <Binding Path="."/>
                        <Binding Path="IsActive"/>
                        <Binding Path="IsPaused"/>
                    </MultiBinding>
                </Border.Background>
            </Border>
            <StackPanel Grid.Row="0" Grid.Column="1"
                        Orientation="Horizontal"
                        Margin="0 2">
                <ComboBox ItemsSource="{Binding Source={StaticResource TaskTypes}}"
                          SelectedItem="{Binding Type}"
                          Text="{Binding Type}"
                          Visibility="{Binding IsActive, Converter={StaticResource BoolToVis}}"/>
                <TextBlock Text="{Binding Type}"
                           FontWeight="Bold"
                           Visibility="{Binding IsActive, Converter={StaticResource InvBoolToVis}}"/>
                <TextBlock Text=" task"/>
            </StackPanel>
            ...
        </Grid>
    </DataTemplate>
    <DataTemplate x:Key="TaskNotSelectedTemplate">
        <Grid Margin="4">
            ...
            <Border Grid.Row="0" Grid.Column="0" Grid.RowSpan="4" Margin="0 0 4 0"
                    BorderThickness="0" 
                    CornerRadius="2">
                <Border.Background>
                    <MultiBinding Converter="{StaticResource ActiveToColor}">
                        <Binding Path="."/>
                        <Binding Path="IsActive"/>
                        <Binding Path="IsPaused"/>
                    </MultiBinding>
                </Border.Background>
            </Border>
            <TextBlock Grid.Row="0" Grid.Column="1"
                       Text="{Binding Type}"/>
            <TextBlock Grid.Row="0" Grid.Column="2"
                       TextAlignment="Right">
                    <Run Text="{Binding Length.TotalMinutes, StringFormat='0', Mode=OneWay}"/>
                    <Run Text=" min"/>
                </TextBlock>
            <TextBlock Grid.Row="0" Grid.Column="3"
                       TextAlignment="Right">
                    <Run Text="{Binding TimesPerformed, Mode=OneWay}"/>
                    <Run Text=" tasks"/>
                </TextBlock>            
        </Grid>
    </DataTemplate>
    <Style x:Key="ContainerStyle" TargetType="{x:Type ListBoxItem}">
        <!--this part changes the selected item highlight color-->
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type ListBoxItem}">
                    <Border Name="Border">
                        <ContentPresenter />
                    </Border>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsSelected" Value="true">
                            <Setter TargetName="Border" 
                                    Property="Background" Value="#2000BFFF">
                            </Setter>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
        <!--this part causes selected task to expand-->
        <Setter Property="ContentTemplate" Value="{StaticResource TaskNotSelectedTemplate}"/>
        <Style.Triggers>
            <Trigger Property="IsSelected" Value="True">
                <Setter Property="ContentTemplate" Value="{StaticResource TaskSelectedTemplate}"/>
            </Trigger>
        </Style.Triggers>
    </Style>
