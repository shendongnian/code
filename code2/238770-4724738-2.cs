    <TabControl Name="Farms_myVillages" 
               ItemsSource="{Binding Villages}">
           <TabControl.ItemTemplate>
                <DataTemplate>
                     <TextBlock Text="{Binding Name}"/>
                </DataTemplate>
           </TabControl.ItemTemplate>
          <TabControl.ContentTemplate>
                <DataTemplate>
                    <u:VillageResources/>
                </DataTemplate>
          </TabControl.ContentTemplate>
    </TabControl>
