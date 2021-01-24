csharp
        private void AddNamespaceButton_Click(object sender, RoutedEventArgs e)
        {
            // Add new Row and begin editing
            KnownNamespaces.Insert(0, new XmlnsNamespace(string.Empty, string.Empty));
            NamespaceDataGrid.SelectedIndex = 0;
            NamespaceDataGrid.ScrollIntoView(NamespaceDataGrid.SelectedItem, null);
            NamespaceDataGrid.Focus(FocusState.Keyboard);
            NamespaceDataGrid.BeginEdit();
        }
The next piece is the key for the DataGridTextColumn type to ensure the focus of the cell gets transferred to the focus of the TextBox inside when editing:
csharp
        private void NamespaceDataGrid_PreparingCellForEdit(object sender, Microsoft.Toolkit.Uwp.UI.Controls.DataGridPreparingCellForEditEventArgs e)
        {
            if (e.EditingElement is TextBox t)
            {
                t.Focus(FocusState.Keyboard);
            }
        }
It's also important to note that the class that your ObservableCollection consists of should implement the `IEditableObject` interface to work properly with the DataGrid.
---
Here's my XAML for completeness:
xaml
<StackPanel Margin="{StaticResource SettingsSubheaderMargin}">
                        <StackPanel Orientation="Horizontal">
                            <TextBlock x:Uid="SettingsPanel_KnownNamespaces"
                                       Margin="0,8,0,12"
                                       Style="{StaticResource BodyTextStyle}" />
                            <Button x:Uid="SettingsPanel_KnownNamespaces_Button_Add" Click="AddNamespaceButton_Click" Style="{StaticResource VSCodeAppBarHeaderButtonStyle}">
                                <SymbolIcon Symbol="Add" />
                            </Button>
                        </StackPanel>
                        <controls:DataGrid x:Name="NamespaceDataGrid"
                                           MaxHeight="450"
                                           AutoGenerateColumns="False"
                                           Background="{ThemeResource Brush-Blue-Dark-1}"
                                           CanUserReorderColumns="False"
                                           CanUserSortColumns="True"
                                           IsReadOnly="False"
                                           ItemsSource="{x:Bind KnownNamespaces, Mode=OneWay}"
                                           PreparingCellForEdit="NamespaceDataGrid_PreparingCellForEdit"
                                           RowEditEnded="DataGrid_RowEditEnded">
                            <controls:DataGrid.Columns>
                                <controls:DataGridTextColumn Width="SizeToCells"
                                                             Binding="{Binding Name}"
                                                             FontSize="20"
                                                             Header="Shortcut" />
                                <controls:DataGridTextColumn Width="SizeToCells"
                                                             Binding="{Binding Path}"
                                                             FontSize="20"
                                                             Header="Namespace" />
                                <controls:DataGridTemplateColumn>
                                    <controls:DataGridTemplateColumn.CellTemplate>
                                        <DataTemplate>
                                            <Button x:Uid="SettingsPanel_KnownNamespaces_Button_Remove"
                                                    Click="RemoveNamespaceButton_Click"
                                                    CommandParameter="{Binding}"
                                                    Style="{StaticResource VSCodeAppBarHeaderButtonStyle}">
                                                <SymbolIcon Symbol="Delete" />
                                            </Button>
                                        </DataTemplate>
                                    </controls:DataGridTemplateColumn.CellTemplate>
                                </controls:DataGridTemplateColumn>
                            </controls:DataGrid.Columns>
                        </controls:DataGrid>
                    </StackPanel>
I use the RowEditEnding event to save my data model back to disk.
