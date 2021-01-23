    <Grid>
      <Grid.Resources>
        <BoolToVisibilityConverter x:Key="BoolToVisibilityConverter" />
      </Grid.Ressources>
      <ToggleButton x:Name="toggleButton" Content="Toggle" />
      <Grid Visibility={Binding IsChecked, ElementName=toggleButton, Converter={StaticResource BoolToVisibilityConverter}}>
        <!-- place your content here -->
      </Grid>
    </Grid>
