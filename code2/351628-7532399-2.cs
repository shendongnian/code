    <ContextMenu ItemsSource="{Binding Owners}">
      <ContextMenu.ItemTemplate>
          <DataTemplate>
               <TextBlock Text="{Binding Title}"/>
          </DataTemplate>
      </ContextMenu.ItemTemplate>
    </ContextMenu>
