    <NavigationView>
            <NavigationView.HeaderTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Horizontal">
                        <CommandBar Background="{ThemeResource SystemControlAltHighAcrylicWindowBrush}"
                Visibility="{Binding listsClicked, Converter={StaticResource boolToVisibilityConverter}}"
                        Height="30">
                            <AppBarButton Icon="Back" Label="Back"/>
                        </CommandBar>
                        <CommandBar Background="{ThemeResource SystemControlAltHighAcrylicWindowBrush}"
                Visibility="{Binding addinCalculatorClicked, Converter={StaticResource boolToVisibilityConverter}}"
                        Height="40">
                            <AppBarButton Icon="Forward" Label="Forward"/>
                        </CommandBar>
                    </StackPanel>
                </DataTemplate>
            </NavigationView.HeaderTemplate>
    </NavigationView>
