    <ItemsControl ItemsSource="{Binding}">
      <ItemsControl.ItemsPanel>
        <ItemsPanelTemplate>
          <Grid>
            <Grid.RowDefinitions>
              <RowDefinition Height="10"/>
              <RowDefinition Height="10"/>
              <RowDefinition Height="10"/>
              <RowDefinition Height="10"/>
            </Grid.RowDefinitions>
            <Grid.ColumnDefinitions>
              <ColumnDefinition Width="10"/>
              <ColumnDefinition Width="10"/>
              <ColumnDefinition Width="10"/>
              <ColumnDefinition Width="10"/>
            </Grid.ColumnDefinitions>
          </Grid>      
        </ItemsPanelTemplate>
      </ItemsControl.ItemsPanel>
      <ItemsControl.ItemContainerStyle>
        <Style TargetType="ContentPresenter">
          <Setter Property="Grid.Row" Value="{Binding Row}"/>
          <Setter Property="Grid.Column" Value="{Binding Column}"/>
        </Style>
      </ItemsControl.ItemContainerStyle>
      <ItemsControl.ItemTemplate>
        <DataTemplate TargetType="{x:Type MyClass}">
          <TextBlock Text="{Binding Letter}"/>
        </DataTemplate>
      </ItemsControl.ItemTemplate>
    </ItemsControl>
