    <TabControl>
       <TabControl.Resources>
         <Style TargetType="TabItem">
            <EventSetter Event="PreviewMouseLeftButtonDown" Handler="OnPreviewMouseLeftButtonDown"/>
         </Style>  
       </TabControl.Resources>
       <TabItem Header="Tab1"/>
       <TabItem Header="Tab2"/>
    </TabControl>
    private void OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.Source is TabItem) //do not handle clicks on TabItem content but on TabItem itself
        {
            var vm = this.DataContext as MyViewModel;
            if (vm != null)
            {
                if (!vm.CanLeave())
                {
                    e.Handled = true;
                }
            }
        }
    }
