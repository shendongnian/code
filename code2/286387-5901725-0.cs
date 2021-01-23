      <ComboBox ItemsSource="{Binding {DynamicResource Blocks}}">
        <ComboBox.ItemTemplate>
          <DataTemplate>
            <Grid>
              <Grid.ColumnDefinitions>
                <ColumnDefinition Width="Auto"/>
              </Grid.ColumnDefinitions>
              <TextBlock Grid.Column="0" Text="{Binding Text}">
                <TextBlock.Style>
                  <Style TargetType="TextBlock">
                    <Setter Property="Foreground" Value="Black"/>
                    <Style.Triggers>
                      <DataTrigger Binding="{Binding IsBanned}">
                        <Setter Property="Foreground" Value="Red"/>
                      </DataTrigger>
                    </Style.Triggers>
                  </Style>
                </TextBlock.Style>
              </TextBlock>
            </Grid>
          </DataTemplate>
        </ComboBox.ItemTemplate>
      </ComboBox>
