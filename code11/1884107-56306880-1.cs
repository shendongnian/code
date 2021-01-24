            foreach (Control control in Controls)
            {
                if (control is Button theButton && (int)theButton.Tag >= 5)
                {
                    switch ((int) theButton.Tag)
                    {
                        case 100:
                            theButton.Image = P_Farm;
                            break;
                        case 101:
                            theButton.Image = Z_Farm;
                            break;
                    }
                }
            }
