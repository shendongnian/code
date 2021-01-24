public void setBgColor(Color rgb)
{
    foreach (Control c in this.Controls)
    {
        if (c.GetType() == typeof(System.Windows.Forms.Panel))
        {
            c.BackColor = rgb;
        }
    }
}
