            private List<HitTestResult> hitResultsList = new List<HitTestResult>();
    
            private void canvas1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
            {
                if (canvas1.Children.Count > 0)
                {
                    // Retrieve the coordinates of the mouse position.
                    Point pt = e.GetPosition((UIElement)sender);
    
                    // Clear the contents of the list used for hit test results.
                    hitResultsList.Clear();
    
                    // Set up a callback to receive the hit test result enumeration.
                    VisualTreeHelper.HitTest(canvas1,
                                        new HitTestFilterCallback(MyHitTestFilter),
                                        new HitTestResultCallback(MyHitTestResult),
                                        new PointHitTestParameters(pt));
    
                    // Perform actions on the hit test results list.
                    if (hitResultsList.Count > 0)
                    {
                        string msg = null;
                        foreach (HitTestResult htr in hitResultsList)
                        {
                            Rectangle r = (Rectangle)htr.VisualHit;
                            msg += r.Tag.ToString() + "\n";
                        }
                        //Message displaying the tag of all the rectangles 
                        //under the mouse when it was clicked.
                        MessageBox.Show(msg);
                    }
                }
            }
    
            // Filter the hit test values for each object in the enumeration.
            private HitTestFilterBehavior MyHitTestFilter(DependencyObject o)
            {
                // Test for the object value you want to filter.
                if (o.GetType() == typeof(Label))
                {
                    // Visual object and descendants are NOT part of hit test results enumeration.
                    return HitTestFilterBehavior.ContinueSkipSelfAndChildren;
                }
                else
                {
                    // Visual object is part of hit test results enumeration.
                    return HitTestFilterBehavior.Continue;
                }
            }
    
            // Add the hit test result to the list of results.
            private HitTestResultBehavior MyHitTestResult(HitTestResult result)
            {
                //Filter out the canvas object.
                if (!result.VisualHit.ToString().Contains("Canvas"))
                {
                    hitResultsList.Add(result);
                }
                // Set the behavior to return visuals at all z-order levels.
                return HitTestResultBehavior.Continue;
            }
