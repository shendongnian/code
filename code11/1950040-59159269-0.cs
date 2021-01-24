        <ListBox>
            <ListBox.Resources>
                <ContextMenu x:Key="cm">
                    <MenuItem Header="Rename" Click="Rename_Click" />
                </ContextMenu>
            </ListBox.Resources>
            <ListBox.ItemTemplate>
                ...
            </ListBox.ItemTemplate>
            <ListBox.ItemContainerStyle>
                <Style TargetType="ListBoxItem">
                    <Setter Property="ContextMenu" Value="{StaticResource cm}" />
                </Style>
            </ListBox.ItemContainerStyle>
        </ListBox>
