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
Edit: so it wont need any for / foreach statement 
for (int i = 0; i < lines.Length; i++)
            {
                textsplit = lines[i].Split('@');
                MessageBox.Show(textsplit[0]);
                }
            }
just do this and it will fine
Thanks PeterDuniho for the help!
