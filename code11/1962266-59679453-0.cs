    <Grid>
            <Grid.Resources>
                <DataTemplate x:Key="CustomHeaderTemplate">
                    <Label Content="{Binding TabName}" />
                </DataTemplate>
            </Grid.Resources>
    
            <TabControl x:Name="tbCtrl" ItemsSource="{Binding Items}" Loaded="tbCtrl_Loaded" SelectionChanged="tbCtrl_SelectionChanged" ItemTemplate="{StaticResource CustomHeaderTemplate}">
                <TabControl.ContentTemplate>
                    <DataTemplate>
                        <uc:DeviceTab/>
                    </DataTemplate>
                </TabControl.ContentTemplate>
            </TabControl>
    </Grid>
