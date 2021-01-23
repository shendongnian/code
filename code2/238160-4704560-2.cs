    <Grid>
        <ScrollViewer>
             <Grid ScrollViewer.VerticalScrollBarVisibility="Auto"
                  ScrollViewer.HorizontalScrollBarVisibility="Disabled">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition />
                    <ColumnDefinition />
                </Grid.ColumnDefinitions>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition  Width="auto" />
                        <ColumnDefinition />
                    </Grid.ColumnDefinitions>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="auto" />
                        <RowDefinition Height="*" />
                    </Grid.RowDefinitions>
                    <Label Target="{Binding ElementName=textBlock}"
                           VerticalAlignment="Center">_Name:</Label>
                    <TextBox Grid.Column="1"
                             x:Name="textBlock"
                             VerticalAlignment="Center"
                             Text="Enter text here" />
                </Grid>                
                <Border Grid.Column="1">
                    <TextBlock Text="Anything you like" />
                </Border>
            </Grid>
        </ScrollViewer>
    </Grid>
    
