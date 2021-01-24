            // Récupère tous les élèves présents
            List<string> eleve = new List<string>();
            foreach (Control ctrl in panel_eleve.Controls)
            {
                if (ctrl is UserControl) // You may be able to be more specific with this type
                {
                       foreach (Control innerControl in ctrl )
                       {
                           if (ctrl is UserControl)
                           {
                                ComboBox c = ctrl as ComboBox;
                                eleve.Add(c.SelectedText);
                           }
                       }
                }
            }
            addOutil add_outil_window = new addOutil(eleve);
            add_outil_window.ShowDialog();
