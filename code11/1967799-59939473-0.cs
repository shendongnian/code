    <UserControl Name="RootElement" DataContext=.Some Context.....> 
     <UserControl.Resources>
        <BooleanToVisibilityConverter x:Key="BoolToVisibility" />
        <helper:BindingProxy x:Key="Proxy" Data="{Binding}" />
    </UserControl.Resources>    
    <ListView ItemsSource="{Binding LicensesView}">
                <ListView.ItemContainerStyle>
                    <Style TargetType="{x:Type ListViewItem}">
                        <Setter Property="ContextMenu">
                            <Setter.Value>
                                <ContextMenu>
                                    <MenuItem Header="Refresh 1" Command="{Binding Path=Data.LicenseListRefreshCommand, Source={StaticResource Proxy}}" />
                                </ContextMenu>
                            </Setter.Value>                           
                        </Setter>
                  </Style>
                </ListView.ItemContainerStyle>
                <ListView.View>
                    <GridView>
                        <GridViewColumn Header="Code" DisplayMemberBinding="{Binding Code}" Width="Auto"/>
                        <GridViewColumn Header="Active" DisplayMemberBinding="{Binding Active}" Width="150" />
                        <GridViewColumn Header="Company" DisplayMemberBinding="{Binding Company}" Width="60" />
                        <GridViewColumn Header="Demo" DisplayMemberBinding="{Binding Demo}" Width="Auto" />
                    </GridView>
                </ListView.View>
            </ListView>
