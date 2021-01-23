    class ViewModel_B
    {
    	public ViewModel_A MySubViewModel{get;set;}
    }
    
    <DataTemplate x:Key="vmaTemplate" DataType="{x:Type ViewModel_A}">
    	<TextBlock Text="{Binding PersonClass.Name}"/>
    </DataTemplate>
    
    <Grid>
    	<ContentControl Content="{Binding MySubViewModel}" 
               ContentTemplate="{StaticTemplate vmaTemplate}"/>
    </Grid>
