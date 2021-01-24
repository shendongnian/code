    <DataGrid ItemsSource="{Binding Users}"
              AutoGenerateColumns="False">
      <DataGrid.Columns>
        <DataGridTextColumn Header="First name"
                            Binding="{Binding FirstName}" />
        <DataGridTextColumn Header="Last name"
                            Binding="{Binding LastName}" />
        <DataGridTextColumn Header="Full name">
          <DataGridTextColumn.Binding>
            <MultiBinding Converter="{StaticResource NameMultiValueConverter}">
              <Binding Path="FirstName" />
              <Binding Path="LastName" />
            </MultiBinding>
          </DataGridTextColumn.Binding>
        </DataGridTextColumn>
      </DataGrid.Columns>
    </DataGrid>
