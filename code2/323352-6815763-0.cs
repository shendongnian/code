    <data:DataGridTemplateColumn.CellTemplate>
      <DataTemplate>
        <Grid>
          <Shims:DataGridShim x:Name="shim"/>
          <Controls:CommandButton x:Name="btnAdd"
            Style="{StaticResource IsisAddRemoveButton}"
            Command="{Binding Path=ParentDataGrid.DataContext.AddPersonCmd,
              ElementName=shim}"
            CommandParameter="{Binding}">
          </Controls:CommandButton>
        </Grid>
      </DataTemplate>
    </data:DataGridTemplateColumn.CellTemplate>
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
