      <RelativeLayout x:Name="layout">
            <BoxView
                x:Name="redBox"
                RelativeLayout.HeightConstraint="{ConstraintExpression Type=RelativeToParent,
                                                                       Property=Height,
                                                                       Factor=.8,
                                                                       Constant=0}"
                RelativeLayout.WidthConstraint="{ConstraintExpression Type=RelativeToParent,
                                                                      Property=Width,
                                                                      Factor=1,
                                                                      Constant=0}"
                RelativeLayout.YConstraint="{ConstraintExpression Type=RelativeToParent,
                                                                  Property=Height,
                                                                  Factor=.15,
                                                                  Constant=0}"
                Color="Red" />
            
            <BoxView x:Name="blueBox" Color="Blue" />
        </RelativeLayout>
    public Page5 ()
		{
			InitializeComponent ();
            double valuex = (double)Application.Current.Resources["TargetXConstant"];
            double valuey = (double)Application.Current.Resources["TargetYConstant"];
            **layout.Children.Add(blueBox, Constraint.RelativeToView(redBox, (Parent, sibling) => {
                return sibling.X + valuex;
            }), Constraint.RelativeToView(redBox, (parent, sibling) => {
                return sibling.Y + valuey;
            }), Constraint.RelativeToParent((parent) => {
                return parent.Width * .5;
            }), Constraint.RelativeToParent((parent) => {
                return parent.Height * .5;
            }));**
        }
 
