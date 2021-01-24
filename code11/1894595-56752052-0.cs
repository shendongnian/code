    <Grid>
       <TabControl Background="#FF292929" ItemsSource="{Binding AllExecuteButtonInfos}">                     
              <TabControl.Resources>
                  <DataTemplate DataType="{x:Type MyViewModel1}">
                       <MyViewModel1_View ViewModel="{Binding}"/>
                  </DataTemplate>
                  <DataTemplate DataType="{x:Type MyViewModel2}">
                       <MyViewModel2_View ViewModel="{Binding}"/>
                  </DataTemplate>
              </TabControl.Resources>
        </TabControl>
    </Grid>
