    <ListView x:Name=”MainListView” ItemsSource={Binding MyItems}>  
        <ListView.HeaderTemplate>  
            <DataTemplate>  
                <Grid>  
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="*"/>
                    </Grid.ColumnDefinitions>
                       <Label Text=”Column1" Grid.Column="0"/>
    
                       <Label Text=”Column2" Grid.Column="1"/>
               </Grid>
            </DataTemplate>  
        </ListView.HeaderTemplate>  
        <ListView.ItemTemplate>  
            <DataTemplate>  
                <ViewCell>  
                   <Grid>  
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="*"/>
                    </Grid.ColumnDefinitions>
                    <Label Text=”{Binding Element1}" Grid.Column="0"/>
    
                    <Label Text=”{Binding Element2}" Grid.Column="1"/>
                </Grid>
                </ViewCell>  
            </DataTemplate>  
        </ListView.ItemTemplate>  
    </ListView>  
