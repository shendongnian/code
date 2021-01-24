 for (int i = 0; i < lines.Length; i++)
            {
                textsplit = lines[i].Split('@');
                for (int j = 0; j < textsplit.Length; j++)
                {
                    MessageBox.Show(textsplit[0]);
                    break;
                }
            }
and it works!
