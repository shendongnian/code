    public Bitmap imgToDecode;
    private void button2_Click(object sender, EventArgs e)
    {
        textBox2.Text = "";
        Color black = Color.FromArgb(0, 0, 0);
        int i = (imgToDecode.Height * imgToDecode.Width);
        bool[] pixData = new bool[i];
        int p = 0;
        for (int k = 0; k < imgToDecode.Height; k++)
        {
            for (int m = 0; m < imgToDecode.Width; m++)
            {
                pixData[p] = (imgToDecode.GetPixel(m, k) == black);
                    
                p++;
            }
        }
        for (int n = 0; n < pixData.Length; n++)
        {
            textBox2.Text = (textBox2.Text + (Convert.ToInt32(pixData[n])));
        }
    }
