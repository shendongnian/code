                        <StackPanel>
                        <CheckBox Name="chbxAll" Checked="chbxAll_Checked" Unchecked="chbxAll_Unchecked" Indeterminate="chbxAll_Indeterminate" IsThreeState="True" >Select All</CheckBox>
                        <ListView Name="lstFoundedFiles" SelectionChanged="lstFoundedFiles_SelectionChanged" SelectionMode="Multiple" ItemsSource="{Binding Files}">
                            <ListView.Resources>
                                <Style TargetType="ListViewItem">
                                    <Style.Triggers>
                                        <Trigger Property="IsSelected" Value="True">
                                            <Setter Property="Background" Value="Aquamarine"></Setter>
                                        </Trigger>
                                    </Style.Triggers>
                                </Style>
                            </ListView.Resources>
                            <ListView.View>
                                <GridView>
                                    <GridViewColumn Width="50" Header="Check">
                                        <GridViewColumn.CellTemplate>
                                            <DataTemplate>
                                                <CheckBox x:Name="chbxItem" IsChecked="{Binding Path=IsSelected, 
                                                        RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type ListViewItem}}}"/>
                                            </DataTemplate>
                                        </GridViewColumn.CellTemplate>
                                    </GridViewColumn>
                                    <GridViewColumn Header="File">
                                        <GridViewColumn.CellTemplate>
                                            <DataTemplate>
                                                <TextBlock Text="{Binding Name}" ></TextBlock>
                                            </DataTemplate>
                                        </GridViewColumn.CellTemplate>
                                    </GridViewColumn>
                                    <GridViewColumn Header="Location">
                                        <GridViewColumn.CellTemplate>
                                            <DataTemplate>
                                                <TextBlock Text="{Binding Path}"></TextBlock>
                                            </DataTemplate>
                                        </GridViewColumn.CellTemplate>
                                    </GridViewColumn>
                                </GridView>
                            </ListView.View>
                        </ListView>
                    </StackPanel>
