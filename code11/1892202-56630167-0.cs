     private bool myVar;
    
        public bool ShowItem
        {
            get { return myVar; }
            set { myVar = value; OnPropertyChanged("ShowItem"); }
        }
    
    
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowItem = true;
        }
    
        private void Expander_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ShowItem = !ShowItem;
        }
     
    
         <TabControl SelectionChanged="TabControl_SelectionChanged">
                    <TabItem   PreviewMouseLeftButtonDown="Expander_PreviewMouseLeftButtonUp" >
                            <TabItem.Header>
                            <Expander Header="One" IsHitTestVisible="False" 
                          IsExpanded="{Binding ShowItem}" />
                            </TabItem.Header>
                        <TextBlock Background="Red" >
                            <TextBlock.Style>
                                <Style TargetType="TextBlock">
                                    <Setter Property="Visibility" Value="Collapsed"></Setter>
                                    <Style.Triggers>
                                        
                                        <DataTrigger Binding="{Binding ShowItem}" Value="True">
                                            <Setter Property="Visibility" Value="Visible"></Setter>
                                        </DataTrigger>
                                        
                                    </Style.Triggers>
                                </Style >
                            </TextBlock.Style>
                            
                        </TextBlock>
                    </TabItem>
                    <TabItem  PreviewMouseLeftButtonDown="Expander_PreviewMouseLeftButtonUp">
                            <TabItem.Header>
                                <Expander Header="Two" IsHitTestVisible="False" 
                          IsExpanded="{Binding ShowItem}" />
                            </TabItem.Header>
                        <TextBlock Background="Aqua" >
                            <TextBlock.Style>
                                <Style TargetType="TextBlock">
                                    <Setter Property="Visibility" Value="Collapsed"></Setter>
                                    <Style.Triggers>
                                        <DataTrigger Binding="{Binding ShowItem}" Value="True">
                                            <Setter Property="Visibility" Value="Visible"></Setter>
                                        </DataTrigger>
                                       
                                    </Style.Triggers>
                                </Style >
                            </TextBlock.Style>
                        </TextBlock>
                    </TabItem>
                    </TabControl>
