                foreach (Control ctrl in panel_eleve.Controls)
            {
                if (ctrl is UserControl_reponsable)
                {
                    foreach (Control innerControl in ctrl.Controls)
                    {                     
                        ComboBox c = innerControl as ComboBox;
                        eleve.Add(c.Text);
                    }
                }
            }
