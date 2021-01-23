       /*create this resources as global to that perticular xaml. Need not to be put it in App.xaml
         MyControl could be Window or Page or UserControl */
    
           <MyControl.Resources>
        	<Storyboard x:Key="MovingServer" Storyboard.TargetName="MyImage" RepeatBehavior="Forever" >
        		<DoubleAnimation Storyboard.TargetProperty="(Canvas.Left)" Duration="0:0:2" From="30" To="300" BeginTime="0:0:0" />
        		<DoubleAnimation Storyboard.TargetProperty="(Canvas.Left)" Duration="0:0:5" From="300" To="300" BeginTime="0:0:5" />
        		<DoubleAnimation Storyboard.TargetProperty="(Canvas.Left)" Duration="0:0:2" From="300" To="600" BeginTime="0:0:7" />
        		<DoubleAnimation Storyboard.TargetProperty="Opacity" Duration="0:0:2" From="1" To="0" BeginTime="0:0:7" />
        	</Storyboard>
        </MyControl.Resources>
        
    /* <!-- Now use those animation resources, the place where you want. You can use it as static resource and begin stop animation from code behind OR use it as trigger event --> */
        
    /*    <!-- Static resources--> */
        <Canvas>
        	<Image Canvas.Left="0" Canvas.Top="-2" Height="32" Name="MyImage" Width="32" Source="/CCTrayHelper;component/Images/ServerIcon.png" Visibility="Hidden"/>
         <Canvas.Resources>
        	<BeginStoryboard x:Key="serverAnimate" Storyboard="{StaticResource MovingServer}" />
         </Canvas.Resources>
        </Canvas>
        <Button x:Name="ScanButton" onClick="Scanbutton_Click" />
        	
    /* ****************************************************************** */
  
      /*  Code behind to start/stop animation*/
    
    //Get the resource value first on current object, so that when you start/stop the animation, it work only on current object
      Storyboard sbImageAnimate = (Storyboard)this.ServerView.FindResource("MovingServer");
    
    //Start the animation on Button Click 
     protected void Scanbutton_Click(object Sender, EventArgs e)
      {   
       this.MyImage.Visibility = System.Windows.Visibility.Visible; 
       sbImageAnimate.Begin();
      } 
     
     //Stop animation on my own even. You can use it on any event
     private void EventPublisher_OnFinish(object sender, EventArgs args) 
     {   
          Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate() { this.StopScanningAnimation(); });  
     }
         
     private void StopScanningAnimation()  
       {
       sbImageAnimate.Stop();
       this.MyImage.Visibility = System.Windows.Visibility.Hidden; 
       } 
