      var linearLayout = FindViewById<LinearLayout>(Resource.Id.linearlayout_view);
                for (int i = 0; i < linearLayout.ChildCount; i++)
                {
                    View child = linearLayout.GetChildAt(i);
                    if (child.GetType() == typeof(CardView))
                    {
                        var viewGroup = ((ViewGroup)child).GetChildAt(0);
                        for (int j = 0; j < ((ViewGroup)viewGroup).ChildCount; j++)
                        {
                            var viewGroup2 = ((ViewGroup)viewGroup).GetChildAt(j);
                            if (viewGroup2.GetType() == typeof(TextView))
                            {
                                System.Diagnostics.Debug.WriteLine(viewGroup2.GetType().ToString() + ": " + ((TextView)viewGroup2).Text);
                            }
                        }
                    }
                }
