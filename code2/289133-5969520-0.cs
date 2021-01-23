    <ListView ItemsSource="{Binding DpData}">
        <ListView.View>
            <GridView>
                <GridViewColumn>
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <CheckBox IsChecked="{Binding IsActive}"/>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                    <!-- Pass collection to Tag property, relevant member info is in the Content,
                         could also create an array in the Tag if the Content should be nicer
                         looking string. -->
                    <CheckBox Content="IsActive" Click="CheckBox_Click" Tag="{Binding DpData}"/>
                </GridViewColumn>
            </GridView>
        </ListView.View>
    </ListView>
