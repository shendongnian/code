stackView.Distribution = UIStackViewDistribution.Fill;
And don't forget to set the Font of label at the same time
targetLabel.Frame = new CGRect(targetLabel.Frame.X, targetLabel.Frame.Y, 150, 150);
targetLabel.Font = UIFont.SystemFontOfSize(80);
Following is the full code , I set the frame just for test and you can set the frame as you want(if you want to set the equals the size of screen , you should set the frame of label and imageView at same time).
UIStackView stackView = new UIStackView(new CGRect(100,200,300,150));
View.AddSubview(stackView);
stackView.Distribution = UIStackViewDistribution.Fill;
stackView.Spacing = 10;
stackView.BackgroundColor = UIColor.LightGray;
stackView.Axis = UILayoutConstraintAxis.Horizontal;
            
UIImageView imageView = new UIImageView()
{
  ContentMode = UIViewContentMode.ScaleAspectFit,
  BackgroundColor = UIColor.Red           
};
otherLabel = new UILabel
{
  TextColor = UIColor.Black,
  Text = "someTextA",
  Font = UIFont.SystemFontOfSize(40)
};
targetLabel = new UILabel
{
  TextColor = UIColor.Black,
  Text = "4",
  TextAlignment = UITextAlignment.Left,
  Font = UIFont.SystemFontOfSize(100),
  AdjustsFontSizeToFitWidth = true,
  Lines = 0
};
targetLabel.Transform = CGAffineTransform.MakeRotation(new nfloat(Math.PI * 270 / 180.0));
stackView.AddArrangedSubview(imageView);
stackView.AddArrangedSubview(otherLabel);
stackView.AddArrangedSubview(targetLabel);
            
stackView.Center = View.Center;
targetLabel.Frame = new CGRect(targetLabel.Frame.X, targetLabel.Frame.Y, 150, 150);
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/geG8M.png
