                  private bool reverse=false;
                  TimeSpan animationDuration = TimeSpan.FromMilliseconds(500);
                  Storyboard storyboard1 = new Storyboard();                      
                  
                  private void prepareStoryBoard(Button btn)
                  {
                    btn.RenderTransform = new CompositeTransform();
                    DoubleAnimation animationShrink = new DoubleAnimation() { To = 0, 
                      Duration =animationDuration , FillBehavior = FillBehavior.HoldEnd };
                    storyboard1.Children.Add(animationShrink);
                    Storyboard.SetTarget(animationShrink, btn);
                    Storyboard.SetTargetProperty(animationShrink,
                      "(Button.RenderTransform).(CompositeTransform.ScaleX)");
                  }
                  private void toggleAnimate()
                  {
                      if(reverse==false)
                        {
                            storyboard1.AutoReverse = false;
                            storyboard1.Begin();
                            reverse=true;
                        }
                        else
                        {
                            storyboard1.AutoReverse = true;
                            storyboard1.Seek(animationDuration);
                            storyboard1.Resume();
                            reverse = false;
                        }
                  }
