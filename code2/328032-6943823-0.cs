    foreach(Control parent in groupBox2.Controls)
    {
        Panel panel = parent as Panel;
        if (panel != null)
        {
            foreach (Control child in panel.Controls)
            {
                RadioBox radio = child as RadioBox;
                if (radio != null)
                {
                    if (!radio.Checked)
                    {
                        MessageBox.Show(radio.ToString());
                        break;//if AutoCheck of all radio buttons seted to true
                    }
                }
            }
        }
    }
