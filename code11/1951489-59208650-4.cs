    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <ListBox ItemsSource="{Binding Images}"
                 SelectedItem="{Binding SelectedImage}"
                 AllowDrop="True" Drop="ListView_Drop"/>
        <Image Grid.Column="1" Source="{Binding SelectedImage}" />
    </Grid>
