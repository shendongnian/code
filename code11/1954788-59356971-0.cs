    <Expander x:Name="expanderAllDone" IsExpanded="True">
        <Expander.Header>
            <StackPanel Orientation="Horizontal">
                <Button Name="btnAllDone" Content="Close" Click="btnAllDone_Click"/>
            </StackPanel>
        </Expander.Header>
        <Expander.Content>
            <ItemsPresenter/>
        </Expander.Content>
    </Expander>
<!---->
    private void btnAllDone_Click(object sender, RoutedEventArgs e)
    {
        MessageBoxResult result = MessageBox.Show("Are you sure?", "All", MessageBoxButton.YesNo);
        if (result != MessageBoxResult.Yes) 
            return;
        try
        {
            expanderAllDone.IsExpanded = false;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
