        lblrepeated.Text = ""; 
        string value = txtInput.Text;
        char[] arr = value.ToCharArray();
        char[] crr=new char[1];        
       int count1 = 0;        
        for (int i = 0; i < arr.Length; i++)
        {
            int count = 0;  
            char letter=arr[i];
            for (int j = 0; j < arr.Length; j++)
            {
                char letter3 = arr[j];
                    if (letter == letter3)
                    {
                        count++;
                    }                    
            }
            if (count1 < count)
            {
                Array.Resize<char>(ref crr,0);
                int count2 = 0;
                for(int l = 0;l < crr.Length;l++)
                {
                    if (crr[l] == letter)
                        count2++;                    
                }
                
                if (count2 == 0)
                {
                    Array.Resize<char>(ref crr, crr.Length + 1);
                    crr[crr.Length-1] = letter;
                }
                
                count1 = count;               
            }
            else if (count1 == count)
            {
                int count2 = 0;
                for (int l = 0; l < crr.Length; l++)
                {
                    if (crr[l] == letter)
                        count2++;
                }
                if (count2 == 0)
                {
                    Array.Resize<char>(ref crr, crr.Length + 1);
                    crr[crr.Length - 1] = letter;
                }
                count1 = count; 
            }
        }
        
        for (int k = 0; k < crr.Length; k++)
            lblrepeated.Text = lblrepeated.Text + crr[k] + count1.ToString();
