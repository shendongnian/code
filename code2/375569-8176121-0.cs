            protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // Scale the control
            ScaleChildren(this, ref _initialFormSize);
        }
            public static void ScaleChildren(Control control, ref Size initialSize, float fontFactor)
        {
            if (control == null || control.Size == initialSize)
                return;
            SizeF scaleFactor = new SizeF((float)control.Width / (float)initialSize.Width, (float)control.Height / (float)initialSize.Height);
            initialSize = control.Size;
            if (!float.IsInfinity(scaleFactor.Width) || !float.IsInfinity(scaleFactor.Height))
            {
                foreach (Control child in control.Controls)
                {
                    child.Scale(scaleFactor);
                    if (child is Panel)
                        continue;
                    try
                    {
                        // scale the font
                        float scaledFontSize = (float)(int)(child.Font.Size * scaleFactor.Height * fontFactor + 0.5f);
                        System.Diagnostics.Debug.WriteLine(
                            string.Format("ScaleChildren(): scaleFactor = ({0}, {1}); fontFactor = {2}; scaledFontSize = {3}; \"{4}\"",
                            scaleFactor.Width, scaleFactor.Height, fontFactor, scaledFontSize, child.Text));
                        child.Font = new Font(child.Font.Name, scaledFontSize, child.Font.Style);
                    }
                    catch { }
                }
            }
        }
