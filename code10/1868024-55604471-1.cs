     <ComboBox KeyUp="cmbDevice_KeyUp" IsEditable="True" x:Name="cmbDevice" TextSearchEnabled="True" Text="{Binding SelectedDevice,UpdateSourceTrigger=LostFocus}" ItemsSource="{Binding DeviceList }">
                            <ComboBox.ItemsPanel>
                                <ItemsPanelTemplate>
                                    <VirtualizingStackPanel />
                                </ItemsPanelTemplate>
                            </ComboBox.ItemsPanel>
                        </ComboBox>
     private void cmbDevice_KeyUp(object sender, KeyEventArgs e)
            {
                cmbDevice.IsDropDownOpen = true;
            }
