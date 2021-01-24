    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <Image Source="{Binding SelectedImage}" />
        <ListBox Grid.Column="1"
                 ItemsSource="{Binding Images}"
                 SelectedItem="{Binding SelectedImage}"
                 AllowDrop="True" Drop="ListView_Drop"/>
    </Grid>
