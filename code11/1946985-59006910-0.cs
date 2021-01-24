    <Menu DockPanel.Dock="Top" cal:Action.TargetWithoutContext="{Binding DataContext, RelativeSource={RelativeSource Self}}" x:Name="mainMenu">
                <MenuItem Header="_File">
                    <MenuItem Header="_Close" x:Name="Close"/>
                </MenuItem>
                <MenuItem Header="Edit">
                    <MenuItem Header="Settings"/>
                    <MenuItem Header="MediaData"/>
                    <Separator/>
                    <MenuItem Header="Reset"/>
                </MenuItem>
                <MenuItem Header="Categories" ItemsSource="{Binding AvailableCategories}">
                    <MenuItem.ItemTemplate>
                        <DataTemplate>
                            <CheckBox Content="{Binding DisplayText}"  cal:Message.Attach="ChangeSelectedPlaylist($datacontext)"
                                     cal:Action.TargetWithoutContext="{Binding DataContext, ElementName=mainMenu}" />
                        </DataTemplate>
                    </MenuItem.ItemTemplate>
                </MenuItem>
            </Menu>
