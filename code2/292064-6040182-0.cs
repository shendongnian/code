    <ItemsControl ItemsSource="{Binding Albums}">
    <ItemsControl.Template>
        <ControlTemplate>
            <DockPanel>
                <StackPanel Orientation="Vertical" DockPanel.Dock="Left">
                    <Image Source="{Binding AlbumImage}"/>
                    <TextBlock Text="{Binding AlbumName}"/>
                </StackPanel>
                <ListView ItemsSource="{Binding Songs}" >
                    <ListView.View>
                        <GridView>
                            <GridViewColumn DisplayMemberBinding="{Binding SongName}" Header="Name" />
                            <GridViewColumn DisplayMemberBinding="{Binding SongLength}" Header="Length" />
                        </GridView>
                    </ListView.View>
                </ListView>
            </DockPanel>
        </ControlTemplate>
    </ItemsControl.Template>
