    private void transBtn_Click(object sender, EventArgs e)
    {
        // Start with whatever is in plTxtBx
        StringBuilder sb = new StringBuilder(plTxtBx.Text); 
        
        // Break into words
        string[] columns = engTxtBx.Text.Trim().Split(' ');
        for (int i = 0; i < columns.Length; i++)
        {
            if (isVowel(columns[i][0]))
            {
                // Start with vowel.
                sb.Append(columns[i]);
                sb.Append("way");
            }
            else
            {
                // Start with consonant. Get index of first vowel.
                int index = columns[i].IndexOfAny(vowels);
                if (index == -1)
                {
                    // No vowel in columns[i].
                    // You have to decide what to do.
                }
                else if (index == 1)
                {
                    // First vowel is the second letter.
                    sb.Append(columns[i].Substring(1));
                    sb.Append(columns[i][0]);
                    sb.Append("way");
                }
                else
                {
                    // First vowel is after the second letter.
                    sb.Append(columns[i].Substring(index));
                    sb.Append(columns[i].Substring(index - 1, 1));
                    sb.Append("way");
                }
    
            }
        }
        
        // Update plTxtBx's Text once with the final results
        plTxtBx.Text = sb.ToString();
    
    }
