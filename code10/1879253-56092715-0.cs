    private async Task SlidePanel(Control control, int start, int end, int speed)
    {
        while (start < end)
        {
            await Task.Delay(speed);
            start += 1;
            control?.BeginInvoke(new Action(() => control.Left += 1));
        }
    }
    private async void btnSlider_MouseEnter(object sender, EventArgs e)
    {
        btnMainMenu.MouseEnter -= btnMainMenu_MouseEnter;
        pnSideBlock.Left -= pnSideBlock.Width;
        await SlidePanel(pnSideBlock, pnSideBlock.Left, pnSideBlock.Width, 100);
        btnMainMenu.MouseEnter += btnMainMenu_MouseEnter;
    }
