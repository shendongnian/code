    private async void typeButton_Click(object sender, EventArgs e)
    {
        CursorMovementToPoint(PointToScreen(new Point((typeBox.Location.X + (typeBox.Size.Width / 2)), (typeBox.Location.Y + (typeBox.Size.Height / 2)))));
        SendM(MOUSEEVENTF.LEFTDOWN | MOUSEEVENTF.LEFTUP);
        textBox1.Text = "1";
        await Task.Delay(1500);
        SendK(ScanCodeShort.KEY_1);
        textBox1.Text = "2";
        await Task.Delay(1500);
        SendK(ScanCodeShort.KEY_2);
        textBox1.Text = "3";
    }
