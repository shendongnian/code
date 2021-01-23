        <ListView Name="list"
                  Grid.Row="1"                 
                  >
        <ListView.View>        
         <GridView>
            <GridViewColumn Header="Name">
                <GridViewColumn.CellTemplate>
                    <DataTemplate>
                        <Button>
                         <TextBlock Text="{BindingPath=Name}"/>                            
                        </Button>
                    </DataTemplate>
                </GridViewColumn.CellTemplate>
            </GridViewColumn>
            <GridViewColumn Header="Size">
                <GridViewColumn.CellTemplate>
                    <DataTemplate>
                        <Button>
                         <TextBlock Text="{BindingPath=Size}"/>                            
                        </Button>
                    </DataTemplate>
                </GridViewColumn.CellTemplate>
            </GridViewColumn>
            <GridViewColumn Header="Path">
                <GridViewColumn.CellTemplate>
                    <DataTemplate>
                        <Button>
                         <TextBlock Text="{BindingPath=Path}"/>                            
                        </Button>
                    </DataTemplate>
                </GridViewColumn.CellTemplate>
            </GridViewColumn>
        </GridView>
         </ListView.View>  
        </ListView>
