    <TabControl>
    <TabControl.Resources>
        <DataTemplate DataType="EditorTabViewModel">
             <Button Content="Enabled for Editor only" IsEnabled=True Command=SomeCommand />
             <Button Content="Enabled for Preview only" IsEnabled=False Command=SomeCommand />
        </DataTemplate/>
        <DataTemplate DataType="PreviewTabViewModel">
            <Button Content="Enabled for Editor only" IsEnabled=False Command=SomeCommand />
            <Button Content="Enabled for Preview only" IsEnabled=True Command=SomeCommand />
        </DataTemplate>
    </TabControl.Resources>
    <TabControl.ItemTemplate>
        <DataTemplate DataType="TabViewModel">
            <TextBlock Text="{Binding SomeValueToShowAsHeader}" />
        </DataTemplate>
    </TabControl.ItemTemplate>
    </TabControl>
