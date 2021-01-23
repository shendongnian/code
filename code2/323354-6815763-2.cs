    <DataTemplate x:Key="ContactRowDetailTemplate" >
      <Grid Background="Transparent"
        DataContext="{Binding ParentDataGrid.DataContext.ContactStatModel, 
        ElementName=shim,Mode=OneTime}">
            <Shims:DataGridShim x:Name="shim"/>
        <Grid.RowDefinitions>
          <RowDefinition Height="28" />
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
          <ColumnDefinition Width="Auto" />
          <ColumnDefinition Width="Auto" />
          <ColumnDefinition Width="Auto" />
        </Grid.ColumnDefinitions>
        <TextBlock Text="Sent SMS Count" Grid.Column="0" Grid.Row="0" />
        <TextBlock Text=":" Grid.Column="1" Grid.Row="0" />
        <TextBlock Text="{Binding SMSCount}" Grid.Column="2" Grid.Row="0" />
      </Grid>
    </DataTemplate>
    public class DataGridShim : FrameworkElement
    {
      /// <summary>
      /// Initializes a new instance of the <see cref="DataGridShim"/> class.
      /// prepares the ParentDataGrid property for consumption by sibling elements in the DataTemplate
      /// </summary>
      public DataGridShim()
      {
        Loaded += (s, re) =>
        {
          ParentDataGrid = GetContainingDataGrid(this);
        };
      }
    
      /// <summary>
      /// Gets or sets the parent data grid.
      /// </summary>
      /// <value>
      /// The parent data grid.
      /// </value>
      public DataGrid ParentDataGrid { get; protected set; }
    
      /// <summary>
      /// Walks the Visual Tree until the DataGrid parent is found and returns it
      /// </summary>
      /// <param name="value">The value.</param>
      /// <returns>The containing datagrid</returns>
      private static DataGrid GetContainingDataGrid(DependencyObject value)
      {
        if (value != null)
        {
          DependencyObject parent = VisualTreeHelper.GetParent(value);
          if (parent != null)
          {
            var grid = parent as DataGrid;
            if (grid != null)
              return grid;
            
            return GetContainingDataGrid(parent);
          }
          
          return null;
        }
        
        return null;
      }
    }
