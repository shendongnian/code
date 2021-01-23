    	static AutomationElement SelectItem(AutomationElement item)
        {
            if (item != null)
            {
                ((SelectionItemPattern)item.GetCurrentPattern(SelectionItemPattern.Pattern)).Select();
                System.Windows.Point point = item.GetClickablePoint();
                Microsoft.Test.Input.Mouse.MoveTo(new System.Drawing.Point((int)point.X, (int)point.Y));
                Microsoft.Test.Input.Mouse.Click(MouseButton.Left);
            }
            return item;
        }
