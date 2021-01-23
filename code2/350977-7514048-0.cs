    These are the steps to achieve wp7 page unlock animation
    1.	Create the following storyboards
     <Storyboard x:Name="LockScreenSlideAnimation">
           <DoubleAnimation Duration="0:0:1" To="-768"  
           Storyboard.TargetProperty="  
           (UIElement.RenderTransform).  
           (CompositeTransform.TranslateY)" 
           Storyboard.TargetName="LockScreenGrid" d:IsOptimized="True"/>
     </Storyboard>
       	<Storyboard x:Name="CoastGrid" >
     <DoubleAnimationUsingKeyFrames 
       Storyboard.TargetName="LockScreenGrid" 				   	   
        Storyboard.TargetProperty="(UIElement.RenderTransform)
        .(CompositeTransform.TranslateY)">
                        <EasingDoubleKeyFrame x:Name="coastY" 			
				KeyTime="00:00:01" Value="0">
                        </EasingDoubleKeyFrame>
                    </DoubleAnimationUsingKeyFrames>
                </Storyboard>
    2.	Assume that the grid name is LockScreenGrid [Image Grid which will fly up on tap]
    <Grid Grid.Row="1" x:Name="LockScreenGrid" Visibility="{Binding        
      LockScreenGridVisibility}"
       ManipulationDelta="lock_ManipulationDelta"   
        ManipulationCompleted="lock_ManipulationCompleted" >
    3  Implement lock_manipulationCompleted , lock_ManipulationDelta
     private void lock_ManipulationCompleted(object sender, ManipulationCompletedEventArgs  
      e)
        {
            if (this.gridTranslate.TranslateY< 0.0)
            {
                IEasingFunction function;
                this.CoastGrid.Stop();              
                this.gridTranslate.TranslateY = e.TotalManipulation.Translation.Y;              
                if((e.IsInertial)&& (e.FinalVelocities.LinearVelocity.Y<-1500)  ||
                (this.gridTranslate.TranslateY<(base.ActualHeight/-2.0)))
                {                 
                   
                    this.coastY.Value = (-1.0 * this.LockScreenGrid.ActualHeight);
                    function = new CircleEase();                   
                    ((CircleEase)function).Ease(1.0);                  
                }
                else
                {                 
                    this.coastY.Value = 0.0;
                    function = new BounceEase();                   
                    ((BounceEase)function).Ease(0);                   
                    ((BounceEase)function).Ease(2);                    
                    ((BounceEase)function).Ease(5.0);
                }             
                this.coastY.EasingFunction=function;
                this.CoastGrid.Begin();
            }
        }
        private void lock_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {           
            e.Handled = true;         
            this.gridTranslate.TranslateY = (this.gridTranslate.TranslateY +   
            e.DeltaManipulation.Translation.Y);           
            if(this.gridTranslate.TranslateY>0.0)
            {               
                this.gridTranslate.TranslateY = 0.0;
            }
        }
