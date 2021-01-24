    <Window>
      <Window.DataContext>
        <ViewModel />
      </Window.DataContext>
      <ListView ItemsSource="{Binding Persons}">
        <ListView.View>
          <GridView>
            <GridViewColumn DisplayMemberBinding="{Binding FirstName}">
              <GridViewColumnHeader Sort.IsEnabled="True" Content="First Name" />
            </GridViewColumn>
            <GridViewColumn DisplayMemberBinding="{Binding LastName}">
              <GridViewColumnHeader Sort.IsEnabled="True" Content="Last Name" />
            </GridViewColumn>
          </GridView>
        </ListView.View>
      </ListView>
    </Window>
