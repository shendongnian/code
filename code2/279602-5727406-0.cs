    <TabControl ItemsSource="{Binding Data}">
        <TabControl.ItemTemplate>
            <DataTemplate>
                <Button Click="Tab_Click">
                    <Button.Template>
                        <ControlTemplate>
                            <ContentPresenter />
                        </ControlTemplate>
                    </Button.Template>
                    <Button.Content>
                        <!-- Actual header goes here -->
                    </Button.Content>
                </Button>
            </DataTemplate>
        </TabControl.ItemTemplate>
    </TabControl>
