    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <ListView x:Name="listy">
            <ListViewItem>one
            </ListViewItem>
            <ListViewItem>two
            </ListViewItem>
            <ListViewItem>three
            </ListViewItem>
        </ListView>
        <Button Grid.Row="1" Content="Clicky">
            <Button.Style>
                <Style TargetType="Button">
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding SelectedItem, ElementName=listy}" Value="{x:Null}">
                            <Setter Property="IsEnabled" Value="False"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Button.Style>
        </Button>
    </Grid>
