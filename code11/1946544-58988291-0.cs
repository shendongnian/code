           <ComboBox.ItemTemplate>
                <DataTemplate>
                    <CheckBox Content="{Binding Name}" IsChecked="{Binding IsSelected}"
                              Command="{Binding RelativeSource={RelativeSource FindAncestor,AncestorType={x:Type ComboBox}},Path=DataContext.DeptSelectedCommand}" />
                </DataTemplate>
            </ComboBox.ItemTemplate>
