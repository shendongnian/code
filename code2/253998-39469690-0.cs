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
            var vm = this.DataContext as MyViewModel;
            if (vm != null)
            {
                if (!vm.CanLeave())
                {
                    e.Handled = true;
                }
            }
        }
