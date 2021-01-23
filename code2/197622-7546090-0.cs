        public void TextViewCreated(IWpfTextView textView)
        {
            textView.GotAggregateFocus += TextViewCameToFocus;
            // Do stuff when a new IWpfTextView is created...
        }
        void TextViewCameToFocus(object sender, EventArgs e)
        {
            var focusedTextView = (IWpfTextView)sender;
            // Do stuff when a specific IWpfTextView comes to focus...
        }
