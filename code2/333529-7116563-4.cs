        private void BackButton_Click(object sender, EventArgs e)
        {
            this.CurrentLineIndex--;
        }
        private void ForwardButton_Click(object sender, EventArgs e)
        {
            this.CurrentLineIndex++;
        }
        private void UpdateContentLabel()
        {
            this.ContentLabel.Text = _lines[CurrentLineIndex];
        }
