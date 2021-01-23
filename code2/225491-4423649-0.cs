        // In the constructor or any approp place
        button.MouseEnter += new MouseEventHandler(b_MouseEnter);
        button.MouseLeave += new MouseEventHandler(b_MouseLeave);
        void b_MouseLeave(object sender, MouseEventArgs e)
        {
            button.Background=bgBrush;
        }
        void b_MouseEnter(object sender, MouseEventArgs e)
        {
            button.Background = bgMouseOverBrush;
        }
