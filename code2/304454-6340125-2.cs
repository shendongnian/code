    private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this._index -= 1;
            if (_index >= 0)
                txtMain.Text = this._clients[_index].Name;
            else
                this._index += 1;
           
        }
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            this._index += 1;
            if (_index < this._clients.Count)
                txtMain.Text = this._clients[_index].Name;
            else
                this._index -= 1;
        }
