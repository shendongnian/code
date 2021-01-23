    <ListView Height="238" 
                  HorizontalAlignment="Left" 
                  Name="listView1" 
                  VerticalAlignment="Top" 
                  Width="503"
                  ItemsSource="{Binding}"
                  IsSynchronizedWithCurrentItem="True"
                  SelectionChanged="listView1_SelectionChanged">
            <ListView.View>
                <GridView>
                    <GridView.Columns>
                        <GridViewColumn>
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>
                                   <CheckBox Tag="{Binding ID}" IsChecked="{Binding RelativeSource={RelativeSource AncestorType={x:Type ListViewItem}}, Path=IsSelected}" />  
                               </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                        <GridViewColumn DisplayMemberBinding="{Binding ID}" Header="ID" />
                        <GridViewColumn DisplayMemberBinding="{Binding Name}" Header="Name" />
                    </GridView.Columns>
                </GridView>
            </ListView.View>
        </ListView>
