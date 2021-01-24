    private void textbox_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            float float1 = 0, float2 = 0, float3 = 0;
            if (float.TryParse(textBox1.Text, float1) && 
                float.TryParse(textBox2.Text, out float2) && 
                float.TryParse(textBox3.Text, out float3)) 
            {
                textBo4.Text = (float1 + float2 + float3).ToString();
            }
            else 
            {
                textBox4.Text = "";
            }
        }
        catch 
        {
            textBox4.Text = "";
        }
    }
