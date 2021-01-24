        public class TextViewDelegate : UITextViewDelegate
        {
            private UITextView myTextView;
            bool secureTextViewEntry;       // default is NO
            NSMutableString secureText;
            NSTimer timer;
            NSString lastText;
            public TextViewDelegate(UITextView myTextView)
            {
                this.myTextView = myTextView; 
                secureTextViewEntry = false;
                secureText = new NSMutableString();
            }
    
            public override bool ShouldChangeText(UITextView textView, NSRange range, string text)
            {
                if("\n" == text)
                {
                    textView.ResignFirstResponder();
                    return false;
                }
                lastText = new NSString(text);
                return true;
                //return base.ShouldChangeText(textView, range, text);
            }
    
            public override void Changed(UITextView textView)
            {
                Console.WriteLine("-----" + secureText);
                if (secureTextViewEntry)
                {
                    string text = textView.Text;
                    if(text.Length > 0)
                    {
                        if("" == lastText)
                        {
                            secureText.DeleteCharacters(new NSRange(secureText.Length - 1, 1));
                            onlyPassword();
                            timer.Invalidate();
                            //base.Changed(textView);
                            return;
                        }
                        else
                        {
                            NSString one = new NSString(text.Substring(text.Length - 1));
                            secureText.Append(one);
                            NSMutableString temp = new NSMutableString();
                            for (int i = 0; i < secureText.Length - 1; i++)
                            {
                                temp.Append(new NSString("•"));
                            }
                            temp.Append(new NSString(secureText.ToString().Substring(secureText.ToString().Length - 1)));
                            myTextView.Text = temp;
    
                            //timer.Invalidate();
                            timer =NSTimer.CreateScheduledTimer(2, onlyPassword);
                        }
                    }
                    else
                    {
                        secureText = new NSMutableString();
                      
                    }
                    //base.Changed(textView);
                }
                else {
                    if (textView.Text.Length == 0)
                    {
                        secureText = new NSMutableString();
                    }
                    else
                    {
                        secureText = new NSMutableString();
                        secureText.SetString(new NSString(textView.Text));
                    }
    
                    timer.Invalidate();
                    //base.Changed(textView);
                }
    }
              
    
            private void onlyPassword(NSTimer obj)
            {
                //throw new NotImplementedException();
                onlyPassword();
            }
    
            private void onlyPassword()
            {
                //throw new NotImplementedException();
                timer.Invalidate();
                NSMutableString temp = new NSMutableString();
                for(int i = 0; i< secureText.Length; i++)
                {
                    temp.Append(new NSString("•"));
                }
                myTextView.Text = temp;
            }
    
            public override void DidChange(NSKeyValueChange changeKind, NSIndexSet indexes, NSString forKey)
            {
                base.DidChange(changeKind, indexes, forKey);
            }
    
            public void setSecureTextViewEntry(bool _secureTextViewEntry)
            {
                secureTextViewEntry = _secureTextViewEntry;
                if (secureText.Length == 0)
                {
                    return;
                }
                else
                {
                    if (secureTextViewEntry)
                    {
                        //secret
                        NSMutableString aaa = new NSMutableString();
                        for (int i = 0; i < secureText.Length; i++)
                        {
                            aaa.Append(new NSString("•"));
                        }
                        myTextView.Text = aaa;
                    }else{
                        //real word
                        myTextView.Text = secureText;
                        timer.Invalidate();
                    }
                }
                Changed(myTextView);
            }
    
            public bool getSecureTextViewEntry()
            {
                return secureTextViewEntry;
            }
        }
