     <DataGridTemplateColumn>
         <DataGridTemplateColumn.CellTemplate>
             <DataTemplate>
                <ComboBox ItemsSource="{Binding Path=DataContext.AvailableHierarchies, 
                                                RelativeSource={RelativeSource FindAncestor, 
                                                AncestorType={x:Type ItemsControl}} }"
                          DisplayMemberPath="Name"
                          SelectedItem="{Binding Path=DataContext.SelectedHierarchy, 
                                                 RelativeSource={RelativeSource FindAncestor, 
                                                 AncestorType={x:Type ItemsControl}},UpdateSourceTrigger=PropertyChanged }"
                                          >
                <ComboBox.Style>
                    <Style TargetType="ComboBox" BasedOn="{StaticResource {x:Type ComboBox}}">
                        <Style.Triggers>
                            <Trigger Property="ComboBox.ItemsSource" Value="{x:Null}">
                                <Setter Property="Visibility" Value="Collapsed"/>
                            </Trigger>
                        </Style.Triggers>
                    </Style>
                </ComboBox.Style>
            </ComboBox>
        </DataTemplate>
    </DataGridTemplateColumn.CellTemplate>
