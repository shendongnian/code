    <Window
        ...
        DataContext="{Binding RelativeSource={RelativeSource Mode=Self}}" Loaded="Window_Loaded">
        <Window.Resources>
            <local:VisibilityToBoolConverter x:Key="VisibilityToBoolConv"/>
        </Window.Resources>
        <StackPanel Orientation="Vertical">
            <DataGrid ItemsSource="{Binding Data}" Name="DGrid"/>
            <ItemsControl ItemsSource="{Binding ElementName=DGrid, Path=Columns}" Grid.IsSharedSizeScope="True" Margin="5">
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition SharedSizeGroup="A"/>
                                <ColumnDefinition SharedSizeGroup="B"/>
                            </Grid.ColumnDefinitions>
                            <TextBlock Text="{Binding Header}" Margin="5"/>
                            <CheckBox Grid.Column="1"  IsChecked="{Binding Visibility, Converter={StaticResource VisibilityToBoolConv}}" Margin="5" HorizontalAlignment="Center" VerticalAlignment="Center"/>
                        </Grid>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ItemsControl>
        </StackPanel>
    </Window>
