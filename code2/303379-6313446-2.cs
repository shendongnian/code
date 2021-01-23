                <ListBox.ItemTemplate>
                    <DataTemplate>
                        <StackPanel>
                            <Controls:GestureService.GestureListener>
                                <Controls:GestureListener Tap="GestureListener_Tap" />
                            </Controls:GestureService.GestureListener>
                            <TextBlock x:Name="lblLineOne" Text="{Binding LineOne}" />
                            <TextBlock Text="{Binding LineTwo}" />
                        </StackPanel>
                    </DataTemplate>
                </ListBox.ItemTemplate>
