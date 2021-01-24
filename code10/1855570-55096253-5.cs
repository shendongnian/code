    <BoxView
                x:Name="blueBox"
                RelativeLayout.HeightConstraint="{ConstraintExpression Type=RelativeToParent,
                                                                       Property=Height,
                                                                       Factor=.5,
                                                                       Constant=0}"
                RelativeLayout.WidthConstraint="{ConstraintExpression Type=RelativeToParent,
                                                                      Property=Width,
                                                                      Factor=.5,
                                                                      Constant=0}"
                RelativeLayout.XConstraint="{ConstraintExpression Type=RelativeToView,
                                                                  ElementName=redBox,
                                                                  Property=X,
                                                                  Factor=1,
                                                                  Constant={StaticResource TargetXConstant}}"
                RelativeLayout.YConstraint="{ConstraintExpression Type=RelativeToView,
                                                                  ElementName=redBox,
                                                                  Property=Y,
                                                                  Factor=1,
                                                                  Constant={StaticResource TargetYConstant}}"
                Color="Blue" />
