        foreach (Control c in this.Controls)
        {
            if (c is MdiClient)
            {
                c.BackColor = this.BackColor;
            }
        }
