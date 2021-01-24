C#
private void Form1_Shown(object sender, EventArgs e)        
{
    Scale();
}
private void But_Click(object sender, EventArgs e)
{
    Scale();
}
private void Scale()        
{     
    double max = 100;     
    Bitmap bitmap = new Bitmap(Figuur.Width, Figuur.Height);  
    for (int x = 0; x < Figuur.Width; x++)
    {     
        for (int y = 0; y < Figuur.Height; y++) 
        {     
            double a = (double)(x - (Figuur.Width * schaal)) / (double)(Figuur.Width * 0.05);    
            double b = (double)(y - (Figuur.Height * schaal)) / (double)(Figuur.Height * 0.05);      
            Mandelgetal getal = new Mandelgetal(a, b); 
            Mandelgetal waarde = new Mandelgetal(0, 0);
            int i = 0;
            while (i < max)
            {
                //i++; //v1
                waarde.Vermenigvuldig();
                waarde.Toevoegen(getal);
                if (waarde.Wortel() > 2.0)
                    break;
                else
                {
                    if (i % 2.0 == 0.0)
                    {
                        bitmap.SetPixel(x, y, Color.White);
                        i++; //v2
                    }
                    else
                    {
                        bitmap.SetPixel(x, y, Color.Black);
                        i++; //v2
                    }
                } 
            }
            if (a * a + b * b > 4)
                bitmap.SetPixel(x, y, Color.Black);
            Figuur.Image = bitmap;
        }
    }
}
