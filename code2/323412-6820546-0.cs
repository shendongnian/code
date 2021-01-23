    <GridView>
        <GridViewColumn DisplayMemberBinding="{Binding Path=Customers}">
            <GridViewColumnHeader
                Content="Customer"
                MouseDown="GridViewColumnHeader_MouseDown" MouseUp="GridViewColumnHeader_MouseDown">
                <GridViewColumnHeader.ContextMenu>
                    <ContextMenu Name="TheContextMenu">
                        <MenuItem Header="Sort by Customer" />
                        <MenuItem Header="Sort by Address" />
                    </ContextMenu>
                </GridViewColumnHeader.ContextMenu>
            </GridViewColumnHeader>
        </GridViewColumn>
    </GridView>
