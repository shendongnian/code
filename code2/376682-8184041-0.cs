    <DataGrid ItemsSource="{Binding Articles}" 
              AutoGenerateColumns="True"
              AutoGeneratingColumn="DataGrid_AutoGeneratingColumn">
        <DataGrid.Columns>
            <DataGridColumn Binding="{Binding ArticleConfigurationSet.Key}" Header="Key" />
            <DataGridColumn Binding="{Binding ArticleConfigurationSet.Value}" Header="Value" />
        </DataGrid.Columns>
    </DataGrid>
    
    // If we are auto-generating the ArticleConfigurationSet column, 
    // cancel it so that column doesn't get rendered
    void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        if(e.ColumnName == "ArticleConfigurationSet")
            e.Cancel = true;
    }
