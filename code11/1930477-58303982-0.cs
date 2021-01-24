     protected override void OnAppearing()
        {
            base.OnAppearing();
            userName.Focused += InputFocused;
            password.Focused += InputFocused;
            userName.Unfocused += InputUnfocused;
            password.Unfocused += InputUnfocused;
        }
    
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            userName.Focused -= InputFocused;
            password.Focused -= InputFocused;
            userName.Unfocused -= InputUnfocused;
            password.Unfocused -= InputUnfocused;
        }
        void InputFocused(object sender, EventArgs args)
        {
            Content.LayoutTo(new Rectangle(0, -270, Content.Bounds.Width, Content.Bounds.Height));
        }
    
        void InputUnfocused(object sender, EventArgs args)
        {
            Content.LayoutTo(new Rectangle(0, 0, Content.Bounds.Width, Content.Bounds.Height));
        }
