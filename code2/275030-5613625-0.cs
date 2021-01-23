    public Keys KeyChar { get; set; }
    public void MyKeyDown(object sender, KeyEventArgs e) {
        if (e.KeyCode == this.KeyChar) {
            Function();
        }
    }
