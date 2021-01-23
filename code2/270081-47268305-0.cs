    private void txtOutput_TextChanged(object sender, EventArgs e)
        {
            // Set the scrollbars to none. If the content fits within textbox maximum size no scrollbars are needed. 
            txtOutput.ScrollBars = ScrollBars.None;
            // Calculate the width and height the text will need to fit inside the box
            Size size = TextRenderer.MeasureText(txtOutput.Text, txtOutput.Font);
            // Size the box accordingly (adding a bit of extra margin cause i like it that way)
            txtOutput.Width = size.Width + 20;
            txtOutput.Height = size.Height + 30;
            // If the box would need to be larger than maximum size we need scrollbars
            // If height needed exceeds maximum add vertical scrollbar
            if (size.Height > txtOutput.MaximumSize.Height)
            {
                
                txtOutput.ScrollBars = ScrollBars.Vertical;
                // If it also exceeds maximum width add both scrollbars 
                // (You can't add vertical first and then horizontal if you wan't both. You would end up with just the horizontal) 
                if (size.Width > txtOutput.MaximumSize.Width)
                {
                    txtOutput.ScrollBars = ScrollBars.Both;
                }
            }
            // If width needed exceeds maximum add horosontal scrollbar 
            else if (size.Width > txtOutput.MaximumSize.Width)
            {
                txtOutput.ScrollBars = ScrollBars.Horizontal;
            }
        }
