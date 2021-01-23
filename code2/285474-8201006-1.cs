            int convertednumber=0;
            sting EnglishNumbers="";
            for (int i = 0; i < arabicnumbers.Length; i++)
            {
                EnglishNumbers += char.GetNumericValue(textBox1.Text, i);
            }
            convertednumber=Convert.ToInt32(EnglishNumbers);
