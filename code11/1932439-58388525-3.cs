        <ListView Grid.Row="0" Name="listView" IsSynchronizedWithCurrentItem="True" SelectionMode="Single" Margin="10" ItemsSource="{Binding ImportColumns}" >
            <ListView.Resources>
                <local:ListFilterConverter x:Key="myConverter" />
                <sys:Int32 x:Key="keepcolumn1">1</sys:Int32>
            </ListView.Resources>
            <ListView.View>
                <GridView AllowsColumnReorder="False">
                    <GridViewColumn Header="File column" DisplayMemberBinding="{Binding FileColumnHeader}"/>
                    <GridViewColumn Header="Worksheet column" >
                        
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <ComboBox VerticalAlignment="Center" DataContext="{Binding DataContext,RelativeSource={RelativeSource AncestorType={x:Type ListView}}}" 
                                          ItemsSource="{Binding ListOfWorksheetColumns.UnselectedWorksheetColumns, Converter={StaticResource myConverter}, ConverterParameter={StaticResource keepcolumn1}}" 
                                          SelectionChanged="ComboBox_SelectionChanged" SelectedIndex="0">
                                </ComboBox>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                </GridView>
            </ListView.View>
        </ListView>
