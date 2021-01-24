    <Menu Grid.Row="0" Background="White" Name="menu">
       <MenuItem Header="Products"   >
           <MenuItem Name="ProductMenu" Header="Products"  ItemsSource="{Binding Products}"  DisplayMemberPath="Name" >
                        <MenuItem.ItemContainerStyle>
                            <Style TargetType="MenuItem">
                                <Setter Property="Command" Value="{Binding  RelativeSource={RelativeSource   AncestorType=MenuItem}, Path=DataContext.ChangeProduct}"/>
                                <Setter Property="CommandParameter" Value="{Binding}"/>
                            </Style>
                        </MenuItem.ItemContainerStyle>
                    </MenuItem>
    
       </MenuItem>
    </Menu>
