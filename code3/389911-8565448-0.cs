    <TabControl x:Name="TabControl">
        <TabControl.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Header}"  x:Name="grid" />
            </DataTemplate>
        </TabControl.ItemTemplate>
        <!--<local:GeneralView Header="General"/>-->
        <TabItem Header="2006 - 2007">
            <local:TimeConsumingView Header="2006 - 2007"/>
        </TabItem>
        <TabItem Header="2007 - 2008">
            <local:TimeConsumingView Header="2007 - 2008"/>
        </TabItem>
    </TabControl>
