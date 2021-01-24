    <ListView Grid.Row="1" 
              HorizontalAlignment="Stretch" 
              VerticalAlignment="Stretch" 
              ItemsSource="{Binding SelectedItem.listElement}"
              SelectedItem="{Binding SelectedItem}">
        <ListView.ItemContainerStyle>
            <Style TargetType="ListViewItem">
                <Setter Property="HorizontalContentAlignment" Value="Stretch" />
            </Style>
        </ListView.ItemContainerStyle>
        <ListView.ItemTemplate>
            <DataTemplate>
                <ContentControl>
                    <i:Interaction.Triggers>
                        <i:EventTrigger EventName="MouseDoubleClick">
                            <i:InvokeCommandAction  Command="{Binding DataContext.HandleDoubleClickCommand, 
                                RelativeSource={RelativeSource AncestorType=UserControl}}"/>
                        </i:EventTrigger>
                    </i:Interaction.Triggers>
                    <WrapPanel Background="Transparent">
                        <TextBlock Text="Data: " Margin="12"><Run FontWeight="Light" Text="{Binding data}"/></TextBlock>
                    </WrapPanel>
                </ContentControl>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
