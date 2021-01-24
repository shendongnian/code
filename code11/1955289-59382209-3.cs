    <Child Parent="this" Text="Some Text" />
    
    @code{
        public void AddToParent(Child child)
        {
            string text = "new text";
            SetText(child, text);
        }
    
        void SetText(Child item, string text)
        {
            // which binding string should I set?
            item.SetText(text);
           
        }
    }
