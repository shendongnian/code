    <Menu Grid.Row="0" Background="White">
       <MenuItem Header="Products"   >
           <MenuItem Name="ProductMenu" Header="Products"  ItemsSource="{Binding Products}"  DisplayMemberPath="Name" >
                        <MenuItem.ItemContainerStyle>
                            <Style TargetType="MenuItem">
                                 <Setter Property="Command" Value="{Binding  ElementName=ProductMenu, Path=DataContext.ChangeProduct}"/>
                                <Setter Property="CommandParameter" Value="{Binding}"/>
                            </Style>
                        </MenuItem.ItemContainerStyle>
                    </MenuItem>
    
       </MenuItem>
    </Menu>
