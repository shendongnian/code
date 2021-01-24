      <ListBox x:Name="MyListBox" ItemsSource="{Binding PlayingNowItems}" BorderThickness="0" HorizontalContentAlignment="Stretch">
            <ListBox.ItemContainerStyle>
                <Style TargetType="ListBoxItem">
                    <Setter Property="Padding" Value="0"/>
                </Style>
            </ListBox.ItemContainerStyle>
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Button HorizontalContentAlignment="Stretch">
                        <Button.InputBindings>
                            <MouseBinding Gesture="LeftDoubleClick" Command="{Binding DataContext.OuterClickCommand,ElementName=MyListBox}"/>
                        </Button.InputBindings>
                        <Grid HorizontalAlignment="Stretch">
                            <Grid.RowDefinitions>
                                <RowDefinition Height="30" />
                            </Grid.RowDefinitions>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="2.5*" />
                                <ColumnDefinition Width="6*" />
                                <ColumnDefinition Width="4.5*" />
                                <ColumnDefinition Width="5*" />
                                <ColumnDefinition Width="2*" />
                            </Grid.ColumnDefinitions>
                            <Button Content="Play" Grid.Column="0">
                                <Button.InputBindings>
                                    <MouseBinding Gesture="LeftClick" Command="{Binding DataContext.InnerClickCommand,ElementName=MyListBox}"/>
                                </Button.InputBindings>
                            </Button>
                            <Label Content="{Binding Name}" Grid.Column="1"/>
                            <Label Content="{Binding Artist}" Grid.Column="2"/>
                            <Label Content="{Binding Album}" Grid.Column="3"/>
                            <Label Content="{Binding Duration}" Grid.Column="4"/>
                        </Grid>
                    </Button>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
