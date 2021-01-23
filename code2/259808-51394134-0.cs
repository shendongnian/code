    static void FixNumericUpDownMouseWheel(Control c) {
        foreach (var num in c.Controls.OfType<NumericUpDown>())
            num.MouseWheel += FixNumericUpDownMouseWheelHandler;
        foreach (var child in c.Controls.OfType<Control>())
            FixNumericUpDownMouseWheel(child);
    }
    static private void FixNumericUpDownMouseWheelHandler(object sender, MouseEventArgs e) {
        ((HandledMouseEventArgs)e).Handled = true;
        var self = ((NumericUpDown)sender);
        self.Value = Math.Max(Math.Min(
            self.Value + ((e.Delta > 0) ? self.Increment : -self.Increment), self.Maximum), self.Minimum);
    }
