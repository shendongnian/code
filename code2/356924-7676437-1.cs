    <ListView Name="UserSolutionsGrid">
        <ListView.View>
           <GridView>
              <GridViewColumn Header="">
                  <GridViewColumn.CellTemplate>
                      <DataTemplate>
                         <CheckBox HorizontalAlignment="Center" IsChecked="{Binding IsSelected, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ListViewItem}}" />
                       </DataTemplate>
                  </GridViewColumn.CellTemplate>
              </GridViewColumn>
              <GridViewColumn Width="350" DisplayMemberBinding="{Binding Name}" Header="Solution" />
           </GridView>
         </ListView.View>
    </ListView>
