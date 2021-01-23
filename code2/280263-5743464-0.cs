        private void TextBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)        
        {
            // Determine if the keystroke was a letter between A and I
            if (e.KeyCode < Keys.A || e.KeyCode > Keys.I)
            {
                // But allow through the backspace key, 
                // so they can correct their mistakes!
                if (e.KeyCode != Keys.Back)
                {
                    // Now we've caught them! An invalid key was pressed.
                    // Handle it by beeping at the user, and ignoring the key event.
                    System.Media.SystemSounds.Beep.Play();
                    e.SuppressKeyPress = true;
                }
            }
        }
