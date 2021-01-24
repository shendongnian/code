      <TabControl>
            <TabItem Header="Tab1" TabIndex="0">
                <TextBox/>
            </TabItem>
            <TabItem Header="Tab3" TabIndex="1"  >
                <TabItem.Resources>
                    <x:Array x:Key="Items" Type="{x:Type Run}">
                        <Run Text="Foo"/>
                        <Run Text="Bar"/>
                        <Run Text="Baz"/>
                    </x:Array>
                </TabItem.Resources>
                <DataGrid ItemsSource="{StaticResource Items}" />
            </TabItem>
            <TabItem Header="Tab2" TabIndex="2">
                <TextBox/>
            </TabItem>
        </TabControl>
