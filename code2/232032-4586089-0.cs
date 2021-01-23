    <Grid>
      <Grid.ColumnDefinitions>
        <ColumnDefinition Width="Auto" />
        <ColumnDefinition Width="*" />
      </Grid.ColumnDefinitions>
    
      <Image Grid.Column="0" Source="{Binding ImageSourceProperty}" />
      <Label Grid.Column="1" Content="{Binding LabelTextProperty}" />
    </Grid>
