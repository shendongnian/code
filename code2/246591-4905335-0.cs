      <Window.Resources>
        <local:Animals x:Key="animals"/>
        <DataTemplate x:Key="TextTemplate">
            <TextBox Margin="2" Width="60" />
        </DataTemplate>
        <DataTemplate x:Key="ComboTemplate" >
            <ComboBox Width="60" />
        </DataTemplate>
    </Window.Resources>
    <Grid>
        <Controls:DataGrid>
            <Controls:DataGrid.Columns>
                <Controls:DataGridTemplateColumn Header="And/Or" Width="60">
                    <Controls:DataGridTemplateColumn.CellTemplateSelector>
                        <local:CustomTemplateSelector
			TextTemplate="{StaticResource TextTemplate}"
			ComboTemplate="{StaticResource ComboTemplate}"/>
                    </Controls:DataGridTemplateColumn.CellTemplateSelector>
                </Controls:DataGridTemplateColumn>
                <Controls:DataGridComboBoxColumn Header="Field"/>
                <Controls:DataGridComboBoxColumn Header="Operator" MinWidth="70" />
                <Controls:DataGridTextColumn Header="Value" MinWidth="100" Width="*"/>
            </Controls:DataGrid.Columns>
        </Controls:DataGrid>
    </Grid>
        public class CustomTemplateSelector : DataTemplateSelector
    {
      public DataTemplate TextTemplate
      { get; set; }
    	
      public DataTemplate ComboTemplate
      { get; set; }
    	
      public override DataTemplate SelectTemplate(object item, DependencyObject container)
      {
         MyObject obj = item as MyObject;
    
        if (obj != null)
        {
    			// custom logic to select appropriate data template and return
        }
        else
          return base.SelectTemplate(item, container);
      }
    
    
      }
    }
