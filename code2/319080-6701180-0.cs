        foreach (Control c in this.Controls) {
            if (c is Button) {
                ((Button)c).Text = "---";
            }
        }
