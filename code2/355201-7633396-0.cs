    <ComboBox x:Name="cb" ItemSource="{Binding Items}" />
    <ContentControl Content="{Binding SelectedItem, ElementName=cb}" Grid.Column="1">
        <ContentControl.ContentTemplate>
            <DataTemplate>
                <v:SubView /> <!-- Bind properties as appropriate -->
            <DataTemplate>
        <ContentControl.ContentTemplate>
    <ContentControl>
