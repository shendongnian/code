    <ListView ListView.IsColumnContentAlignmentEnabled="True"
              ItemsSource="{Binding Persons}">
      <ListView.View>
        <GridView>
          <GridViewColumn DisplayMemberBinding="{Binding FirstName}"
                          ListView.ColumnContentAlignment="Right"
                          Header="First Name" />
          </GridViewColumn>
          <GridViewColumn DisplayMemberBinding="{Binding LastName}"
                          ListView.ColumnContentAlignment="Center"
                          Header="Last Name" />
          </GridViewColumn>
        </GridView>
      </ListView.View>
    </ListView>
