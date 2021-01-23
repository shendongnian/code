    <TabControl>
        
        <TabControl.Resources>
    	    <DataTemplate x:Key="AugmentedTabItem">
    		    <StackPanel Orientation="Horizontal">
    			    <ContentPresenter Content="{DynamicResource ContentLeft}" Margin="0,0,5,0"/>
                    <ContentPresenter Content="{Binding}"/>
                </StackPanel>
            </DataTemplate>		
        </TabControl.Resources>
        
        <TabItem Header="ÜberTab" HeaderTemplate="{StaticResource AugmentedTabItem}">
           <TabItem.Resources>
                <TextBlock x:Key="ContentLeft" Text=">>>" Foreground="Blue"/>			
            </TabItem.Resources>
        </TabItem>  	
    </TabControl>
