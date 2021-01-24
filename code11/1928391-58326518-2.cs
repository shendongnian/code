    using System;
    using UIKit;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;
    using Foundation;
    
    [assembly: ResolutionGroupName("Xamarin")]
    [assembly: ExportEffect(typeof(MyApp.iOS.CustomRenderers.ShowHidePasswordEffect), "ShowHidePasswordEffect")]
    namespace MyApp.iOS.CustomRenderers
    {
        public class ShowHidePasswordEffect : PlatformEffect
        {
            //The actual text entered by the user.
            private NSMutableString SecureText;
            private NSTimer timer;
            //The last character(s) entered by the user.
            private NSString LastText;
            private UITextView UiTextViewForControl;
            protected override void OnAttached()
            {
                SecureText = new NSMutableString();
                ConfigureControl();
            }
    
            protected override void OnDetached()
            {
                //do nothing
            }
    
    
            private void ConfigureControl()
            {
                if (Control != null)
                { 
                    if (Control is UITextView) {
                        UITextView vUpdatedEntry = (UITextView)Control;
                        this.UiTextViewForControl = vUpdatedEntry;
    
                        var buttonRect = UIButton.FromType(UIButtonType.Custom);
                        buttonRect.SetImage(UIImage.FromBundle("show_black_24"), UIControlState.Normal);
                        buttonRect.TouchUpInside += (object sender, EventArgs e1) => {
                            if (vUpdatedEntry.SecureTextEntry)
                            {
                                vUpdatedEntry.SecureTextEntry = false;
                                buttonRect.SetImage(UIImage.FromBundle("hide_black_24"), UIControlState.Normal);
                            }
                            else
                            {
                                vUpdatedEntry.SecureTextEntry = true;
                                buttonRect.SetImage(UIImage.FromBundle("show_black_24"), UIControlState.Normal);
                            }
                            // Change the text based on whether password is to be hidden or visible.
                            HandleSecureEntryChange(vUpdatedEntry);
                        };
    
                        vUpdatedEntry.ShouldChangeText += (textView, range, toReplaceText) => {
                            if ("\n" == toReplaceText)
                            {   //Drop the keyboard if 'Enter/Return' is pressed
                                vUpdatedEntry.ResignFirstResponder();
                                return false;
                            }
                            //Get the text that was entered, store that in LastText. Return true, so that Changed is called.
                            LastText = new NSString(toReplaceText);
                            return true;
                        };
                        // Add eventHandler for Changed.
                        vUpdatedEntry.Changed += HandleTextChange;
    
                        buttonRect.ContentMode = UIViewContentMode.ScaleToFill;
    
                        UIView paddingViewRight = new UIView(new System.Drawing.RectangleF(0.0f, 0.0f, 30.0f, 18.0f));
                        paddingViewRight.AddSubview(buttonRect);
    
                        buttonRect.TranslatesAutoresizingMaskIntoConstraints = false;
                        buttonRect.CenterYAnchor.ConstraintEqualTo(paddingViewRight.CenterYAnchor).Active = true;
    
                        vUpdatedEntry.AddSubview(paddingViewRight);
    
                        paddingViewRight.TranslatesAutoresizingMaskIntoConstraints = false;
                        paddingViewRight.TrailingAnchor.ConstraintEqualTo(vUpdatedEntry.LayoutMarginsGuide.TrailingAnchor, 8.0f).Active = true;
                        paddingViewRight.HeightAnchor.ConstraintEqualTo(vUpdatedEntry.HeightAnchor).Active = true;
                        paddingViewRight.BottomAnchor.ConstraintEqualTo(vUpdatedEntry.LayoutMarginsGuide.BottomAnchor).Active = true;
                        paddingViewRight.TopAnchor.ConstraintEqualTo(vUpdatedEntry.LayoutMarginsGuide.TopAnchor, -8.0f).Active = true;
                        paddingViewRight.WidthAnchor.ConstraintEqualTo(buttonRect.WidthAnchor, 1.0f, 3.0f).Active = true;
                        vUpdatedEntry.TextContainerInset = new UIEdgeInsets(8.0f, 0.0f, 8.0f, paddingViewRight.Frame.Width + 5.0f);
    
                        Control.Layer.CornerRadius = 4;
                        Control.Layer.BorderColor = new CoreGraphics.CGColor(255, 255, 255);
                        Control.Layer.MasksToBounds = true;
                        vUpdatedEntry.TextAlignment = UITextAlignment.Left;
                    }
                }
            }
    
            private void HandleTextChange(object sender, EventArgs e)
            {
                UITextView customEditor = (UITextView)sender;
                if (customEditor.SecureTextEntry)
                {
                    string text = customEditor.Text;
                    if (text.Length > 0)
                    {
                        //If LastText is empty, that means deletion occured.
                        if ("" == this.LastText)
                        {   //Delete the last character from the actual text
                            this.SecureText.DeleteCharacters(new NSRange(this.SecureText.Length - 1, 1));
                            if (null != timer)
                            {
                                timer.Invalidate();
                            }
                            return;
                        }
                        // If LastText is not empty, that means (a) new character(s) was/were entered.
                        int lastTextLength = ((this.LastText.ToString()).Length); //Number of characters in LastText.
                        if (lastTextLength > 1)
                        {   // If more than one character was entered (usually by pasting)
                            int NewTextStartIndex = (text.Length - lastTextLength);
                            string TempNewCharacters = text.Substring(NewTextStartIndex);
                            // Get all the characters except the last character and add them to the secureText
                            NSString NewCharacters = new NSString(TempNewCharacters.Substring(0, TempNewCharacters.Length - 1));
                            SecureText.Append(NewCharacters);
    
                        }
                        // Get and add the last character
                        NSString LastCharacter = new NSString(text.Substring(text.Length - 1));
                        this.SecureText.Append(LastCharacter);
                        // Change all characters to '●' except the last character
                        NSMutableString temp = new NSMutableString();
                        for (int i = 0; i < this.SecureText.Length - 1; i++)
                        {
                            temp.Append(new NSString("●"));
    
                        }
                        // Add the last character as a plain text to the temp and set that into the editor.
                        temp.Append(new NSString(this.SecureText.ToString().Substring(this.SecureText.ToString().Length - 1)));
                        customEditor.Text = temp;
    
                        if (null != this.timer)
                        {
                            this.timer.Invalidate();
                        }
                        // Wait two seconds before changing the last character to '●'.
                        this.timer = NSTimer.CreateScheduledTimer(2, ChangeToHidden);
                    }
                    else
                    {
                        this.SecureText = new NSMutableString();
                    }
                }
                else
                {
                    // If the password is plain text, then initialize it to the secureText string.
                    SecureText = new NSMutableString();
                    SecureText.SetString(new NSString(customEditor.Text));
                    if (null != timer)
                    {
                        this.timer.Invalidate();
                    }
                }
    
            }
    
            private void ChangeToHidden(object sender)
            {
                // Change all the text entered to '●'
                UITextView customEditor = this.UiTextViewForControl;
                this.timer.Invalidate();
                NSMutableString temp = MakeHiddenText();
                customEditor.Text = temp;
            }
    
            private void HandleSecureEntryChange(object sender)
            {
                if (this.SecureText.Length > 0)
                {   // If SecureTextEntry is true, hide text, else make plain text and clean the timer.
                    UITextView customEditor = (UITextView)sender;
                    if (customEditor.SecureTextEntry)
                    {
                        NSMutableString temp = MakeHiddenText();
                        customEditor.Text = temp;
                    }
                    else
                    {
                        customEditor.Text = this.SecureText;
                        if (null != timer)
                        {
                            this.timer.Invalidate();
                        }
                    }
                }
            }
    
            private NSMutableString MakeHiddenText()
            //Make string of '●''s for the text and return
            {
                NSMutableString temp = new NSMutableString();
                for (int i = 0; i < this.SecureText.Length; i++)
                {
                    temp.Append(new NSString("●"));
                }
                return temp;
            }
    
        }
    }
