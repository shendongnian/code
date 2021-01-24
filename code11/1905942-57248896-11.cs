    <UserControl x:Class="WpfTestRange.Main.Test">
  
      <!-- Set the DataContext of the Test control to an instance of ViewModel -->
      <UserControl.DataContext>
        <local:ViewModel />
      </UserControl.DataContext>
    
      <Grid>
        <StackPanel>
          <Button x:Name="Button"
                  Content="Add tab"
                  Click="Button_Click" />
    
          <MetroAnimatedTabControl x:Name="TabControl" 
                      ItemsSource="{Binding ClsTabs}"
                      TabStripPlacement="Left"
                      DisplayMemberPath="TabName">
            <TabControl.ContentTemplate>
              <DataTemplate DataType="local:Tab">
                <DataGrid AutoGenerateColumns="True" ItemsSource="{Binding Content}" />
              </DataTemplate>
            </TabControl.ContentTemplate>
          </TabControl>
        </StackPanel>
    
      </Grid>
    </UserControl>
