    public override void OnStateChanged(View bottomSheet, int newState)
            {
                switch (newState)
                {          
                    case BottomSheetBehavior.StateExpanded:
                        var lp = bottomView.LayoutParameters;
                        var h = lp.Height; //i could get the bottomsheet height 
                        break;              
                }
            }
