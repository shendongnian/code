                      List<int> results;
                      int target = 0;
                     int nearestValue=0;
                    if (results.Any(ab => ab == target))
                    {
                        nearestValue= results.FirstOrDefault<int>(i => i == target);
                    }
                    else
                    {
                        int greaterThanTarget = 0;
                        int lessThanTarget = 0;
                        if (results.Any(ab => ab > target))
                        {
                            greaterThanTarget = results.Where<int>(i => i > target).Min();
                        }
                        if (results.Any(ab => ab < target))
                        {
                            lessThanTarget = results.Where<int>(i => i < target).Max();
                        }
                        if (lessThanTarget == 0 )
                        {
                            nearestValue= greaterThanTarget;
                        }
                        else if (greaterThanTarget == 0)
                        {
                            nearestValue= lessThanTarget;
                        }
                        else
                        {
                            if (target - lessThanTarget < greaterThanTarget - target)
                            {
                                nearestValue= lessThanTarget;
                            }
                            else
                            {
                                nearestValue= greaterThanTarget;
                            }
                        }
                    }
