    DataContext = new List<List<string>>()
      {
          new List<string>() {"List1-1", "List1-2", "List1-3"},
          new List<string>() {"List2-1", "List2-2", "List2-3"}
      };
    <ListView ItemsSource="{Binding}">
      <ListView.View>
        <GridView>
          <GridView.Columns>
            <GridViewColumn DisplayMemberBinding="{Binding .[0]}" /> 
            <GridViewColumn DisplayMemberBinding="{Binding .[1]}" /> 
            <GridViewColumn DisplayMemberBinding="{Binding .[2]}" /> 
          </GridView.Columns>
        </GridView>
      </ListView.View>
    </ListView>
