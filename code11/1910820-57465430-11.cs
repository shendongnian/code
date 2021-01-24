    private bool IsInsideSelection(Point mouseDown, Point mouseUp, System.Windows.Controls.Button button)
    {
        if (mouseUp.X < mouseDown.X)
        {
            var temp = mouseUp;
            mouseUp = mouseDown;
            mouseDown = temp;
        }
        var buttonPos = button.TransformToAncestor(mainWin).Transform(new Point(0, 0));
        var btnBottomRight = new Point(buttonPos.X + button.Width, buttonPos.Y + button.Height);
        if (buttonPos.X < mouseDown.X || buttonPos.Y < mouseDown.Y)
            return false;
        if (btnBottomRight.X > mouseUp.X || btnBottomRight.Y > mouseUp.Y)
            return false;
        return true;
    }
