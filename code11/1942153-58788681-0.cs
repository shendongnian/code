    <TreeView BorderThickness="0" ItemsSource="{Binding RepereTree}" Width="200" Background="Transparent">
        <TreeView.Resources>
            <SolidColorBrush x:Key="{x:Static SystemColors.HighlightBrushKey}" Color="Transparent" />
            <SolidColorBrush x:Key="{x:Static SystemColors.InactiveSelectionHighlightBrushKey }" Color="Transparent" />
            <SolidColorBrush x:Key="{x:Static SystemColors.ControlBrushKey}" Color="Transparent" />
        </TreeView.Resources>
        <TreeView.ItemTemplate>
            <DataTemplate>
                <TreeViewItem  ItemsSource="{Binding ListeSubReperes}">
                    <TreeViewItem.Header>
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="*"/>
                            </Grid.ColumnDefinitions>
                            <TextBlock Background="Transparent" Foreground="#FF042271" Text="{Binding NameOri}" HorizontalAlignment="Left" VerticalAlignment="Center" MouseMove="mouseOverNameRepere" ToolTip="{Binding Path=ToolTipModifications}" MouseDown="TreeView_Main"/>
                        </Grid>
                    </TreeViewItem.Header>
                    <TreeViewItem.ItemTemplate>
                        <DataTemplate>
                            <Grid Margin="-20,0,0,0">
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width="*"></ColumnDefinition>
                                </Grid.ColumnDefinitions>
                                <TextBlock Background="{StaticResource WindowBackgroundColor}" Foreground="#FF042271" Text="{Binding Name}" Margin="10,0,0,0" HorizontalAlignment="Left" Tag="{Binding IdRepereOri}" VerticalAlignment="Center" Grid.Column="0" MouseDown="TreeView_Sub"/>
                                <!--<TextBlock Foreground="#FF042271" Text="{Binding IdRepereOri}" Margin="10,0,10,0" HorizontalAlignment="Left" VerticalAlignment="Center"  Grid.Column="1"/>-->
                            </Grid>
                        </DataTemplate>
                    </TreeViewItem.ItemTemplate>
                </TreeViewItem>
            </DataTemplate>
        </TreeView.ItemTemplate>
    </TreeView>
