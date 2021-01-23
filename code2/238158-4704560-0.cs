    <Grid>
        <ScrollViewer>
             <Grid ScrollViewer.VerticalScrollBarVisibility="Auto"
                  ScrollViewer.HorizontalScrollBarVisibility="Disabled">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition />
                    <ColumnDefinition />
                </Grid.ColumnDefinitions>
                <StackPanel>
                    <TextBlock Text="Label" />
                    <TextBox />
                </StackPanel>
                <Border Grid.Column="1">
                    <TextBlock Text="Anything you like" />
                </Border>
            </Grid>
        </ScrollViewer>
    </Grid>
    
