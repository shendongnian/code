    <ControlTemplate x:Key="ValidationControlTemplate">
        <DockPanel Visibility="{Binding ElementName=Placeholder, Path=Visibility}">
            <Image x:Name="Image"
                           DockPanel.Dock="Right"
                           VerticalAlignment="Center"
                           Margin="0,-2"
                           Style="{StaticResource InformationImageStyle}">
                <Image.ToolTip>
                    <ItemsControl ItemsSource="{Binding}">
                        <ItemsControl.ItemTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding ErrorContent}"/>
                            </DataTemplate>
                        </ItemsControl.ItemTemplate>
                    </ItemsControl>
                </Image.ToolTip>
            </Image>
            <Grid>
                <AdornedElementPlaceholder Name="Placeholder" VerticalAlignment="Center"/>
            </Grid>
        </DockPanel>
        <ControlTemplate.Triggers>
            <DataTrigger Binding="{Binding AdornedElement.Text.Length, ElementName=Placeholder}" Value="0">
                <Setter Property="DockPanel.Dock" TargetName="Image" Value="Left"/>
                <Setter Property="Margin" TargetName="Image" Value="-20,-2"/>
            </DataTrigger>
        </ControlTemplate.Triggers>
    </ControlTemplate>
