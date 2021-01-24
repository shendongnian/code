        <Window.Resources>
            <DataTemplate DataType="{x:Type local:User}">
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*"/>
                    </Grid.ColumnDefinitions>
                    <Grid.RowDefinitions>
                        <RowDefinition Height="*"/>
                    </Grid.RowDefinitions>
                    <StackPanel>
                        <Button Name="BtnGetStatus"
                                Click="BtnGetStatus_Click"
                                Visibility="{Binding Visibility}"
                                IsEnabled="{Binding IsEnabled}"
                            Content="Click to start Expensive Operation">
                        </Button>
                    </StackPanel>
                </Grid>
            </DataTemplate>
            <CollectionViewSource 
              Source="{Binding Source={x:Static local:MainWindow.Users}}"   
              x:Key="dataViewSource" />
        </Window.Resources>
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="3*"/>
                <ColumnDefinition Width="*"/>
            </Grid.ColumnDefinitions>
            <Grid.RowDefinitions>
                <RowDefinition Height="*"/>
            </Grid.RowDefinitions>
            <ListView Name="lv_data" 
                  ItemsSource="{Binding Source={StaticResource dataViewSource}}"
                  SelectionMode="Single">
                <ListView.View>
                    <GridView>
                        <GridViewColumn Header="ID" DisplayMemberBinding="{Binding Path=UserID}"/>
                        <GridViewColumn Header="Username" DisplayMemberBinding="{Binding Path=Username}"/>
                        <GridViewColumn Header="Is Enabled" DisplayMemberBinding="{Binding Path=IsEnabled}"/>
                    </GridView>
                </ListView.View>
            </ListView>
            <ContentControl Grid.Column="1"
                        Width="Auto"
                        Content="{Binding ElementName=lv_data, Path=SelectedItem}">
            </ContentControl>
        </Grid>
    </Window>
