            <TreeView.Resources>
                <!-- Brushes for the selected item -->
                <LinearGradientBrush x:Key="{x:Static SystemColors.HighlightBrushKey}" EndPoint="0,1" StartPoint="0,0">
                    <GradientStop Color="#FFDCEBFC" Offset="0"/>
                    <GradientStop Color="#FFC1DBFC" Offset="1"/>
                </LinearGradientBrush>
                <LinearGradientBrush x:Key="{x:Static SystemColors.ControlBrushKey}" EndPoint="0,1" StartPoint="0,0">
                    <GradientStop Color="#FFF8F8F8" Offset="0"/>
                    <GradientStop Color="#FFE5E5E5" Offset="1"/>
                </LinearGradientBrush>
                <SolidColorBrush x:Key="{x:Static SystemColors.HighlightTextBrushKey}" Color="Black" />
                <SolidColorBrush x:Key="{x:Static SystemColors.ControlTextBrushKey}" Color="Black" />
                <HierarchicalDataTemplate DataType="{x:Type vm:ServerViewModel}" ItemsSource="{Binding Children}">
                    <StackPanel Orientation="Horizontal" Margin="2,1,5,2">
                        <StackPanel.ContextMenu>
                            <ContextMenu>
                                <MenuItem Header="Refresh">
                                    <MenuItem.Icon>
                                        <Image Source="/Content/ServerExplorer/RefreshIcon.png"></Image>
                                    </MenuItem.Icon>
                                </MenuItem>
                            </ContextMenu>
                        </StackPanel.ContextMenu>
                        <Grid Margin="0,0,3,0">
                            <Image Name="icon" Source="/Content/ServerExplorer/ServerIcon.png" Height="16" Width="16"></Image>
                        </Grid>
                        <TextBlock Text="{Binding Name}" />
                    </StackPanel>
                </HierarchicalDataTemplate>
                
                <HierarchicalDataTemplate DataType="{x:Type vm:DatabaseViewModel}" ItemsSource="{Binding Children}">
                    <StackPanel Orientation="Horizontal" Margin="2,1,5,2">
                        <StackPanel.ContextMenu>
                            <ContextMenu>
                                <MenuItem Header="Refresh">
                                    <MenuItem.Icon>
                                        <Image Source="/Content/ServerExplorer/RefreshIcon.png"></Image>
                                    </MenuItem.Icon>
                                </MenuItem>
                            </ContextMenu>
                        </StackPanel.ContextMenu>
                        <Grid Margin="0,0,3,0">
                            <Image Name="icon" Source="/Content/ServerExplorer/DatabaseIcon.png" Height="16" Width="16"></Image>
                        </Grid>
                        <TextBlock Text="{Binding Name}" />
                    </StackPanel>
                </HierarchicalDataTemplate>
                <DataTemplate DataType="{x:Type vm:TableViewModel}">
                    <StackPanel Orientation="Horizontal" Margin="2,1,5,2">
                        <StackPanel.ContextMenu>
                            <ContextMenu>
                                <MenuItem Header="Script Records" Click="ScriptRecords_Click">
                                    <MenuItem.Icon>
                                        <Image Source="/Content/ServerExplorer/ScriptIcon.png"></Image>
                                    </MenuItem.Icon>
                                </MenuItem>
                                <MenuItem Header="Script Table">
                                    <MenuItem.Icon>
                                        <Image Source="/Content/ServerExplorer/ScriptIcon.png"></Image>
                                    </MenuItem.Icon>
                                </MenuItem>
                                <MenuItem Header="Create Replication">
                                    <MenuItem.Icon>
                                        <Image Source="/Content/ServerExplorer/ReplicationIcon.png"></Image>
                                    </MenuItem.Icon>
                                </MenuItem>
                            </ContextMenu>
                        </StackPanel.ContextMenu>
                        <Grid Margin="0,0,3,0">
                            <Image Name="icon" Source="/Content/ServerExplorer/TableIcon.png" Height="16" Width="16"></Image>
                        </Grid>
                        <TextBlock Text="{Binding Name}" />
                    </StackPanel>
                </DataTemplate>
                <DataTemplate DataType="{x:Type vm:StoredProcedureViewModel}">
                    <StackPanel Orientation="Horizontal" Margin="2,1,5,2">
                        <StackPanel.ContextMenu>
                            <ContextMenu>
                                <MenuItem Header="Script Procedure">
                                    <MenuItem.Icon>
                                        <Image Source="/Content/ServerExplorer/ScriptIcon.png"></Image>
                                    </MenuItem.Icon>
                                </MenuItem>
                            </ContextMenu>
                        </StackPanel.ContextMenu>
                        <Grid Margin="0,0,3,0">
                            <Image Name="icon" Source="/Content/ServerExplorer/StoredProcedureIcon.png" Height="16" Width="16"></Image>
                        </Grid>
                        <TextBlock Text="{Binding Name}" />
                    </StackPanel>
                </DataTemplate>
           </TreeView.Resources>
