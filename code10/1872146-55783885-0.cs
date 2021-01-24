        <ListBox ItemsSource="{Binding People}">
            <ListBox.ItemContainerStyle>
                <Style TargetType="{x:Type ListBoxItem}">
                    <Setter Property="IsSelected" Value="{Binding IsSelected, Mode=TwoWay}"/>
                </Style>
            </ListBox.ItemContainerStyle>
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Button  Command="{Binding DataContext.ItemClickCommand, RelativeSource={RelativeSource AncestorType={x:Type ListBox}}}"
                             CommandParameter="{Binding}"
                             >
                        <Button.Template>
                            <ControlTemplate>
                                <StackPanel Orientation="Horizontal">
                                    <TextBlock Text="{Binding LastName}"/>
                                    <Button Command="{Binding DataContext.EllipseCommand, RelativeSource={RelativeSource AncestorType={x:Type ListBox}}}"
                                    >
                                        <Button.Template>
                                            <ControlTemplate>
                                                <Ellipse Name = "TheEllipse" Stroke="Black" 
                                             Fill="Transparent"
                                             Height ="12"                                  
                                             Width="12" Cursor="Hand">
                                                </Ellipse>
                                            </ControlTemplate>
                                        </Button.Template>
                                    </Button>
                                </StackPanel>
                            </ControlTemplate>
                        </Button.Template>
                    </Button>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
