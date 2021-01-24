       <ItemsControl ItemsSource="{Binding Items}">
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="*"  />
                                <ColumnDefinition Width="*"  />
                            </Grid.ColumnDefinitions>
                            <Label  Content="{Binding Name}" Grid.Column="0" />
                            <ComboBox  ItemsSource="{Binding Items ,RelativeSource={RelativeSource Mode=FindAncestor,AncestorType=ItemsControl}}" Grid.Column="1"  
                                      DisplayMemberPath="Name" SelectedItem="{Binding SelectedItem}"/>
                        </Grid>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ItemsControl>
