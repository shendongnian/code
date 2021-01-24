c#
int Naslov_rnd;
private void Naslov_p_Click(object sender, EventArgs e)
{
    TextBox tb = new TextBox();
    VizitKartica.SuspendLayout(); // Call before changing TextBox properties
    tb.Location = new Point(0, 0);
    tb.Multiline = true; // Set before changing width/height
    tb.Size = new Size(200, 20); // Use Size property
    tb.BorderStyle = BorderStyle.None;
    tb.BackColor = Color.DodgerBlue;
    tb.ForeColor = Color.White;
    tb.Name = "Naslov_" + Naslov_rnd.ToString();;
    tb.Text = "Dodajte Vaš naslov";
    tb.Font = new Font("Microsoft Sans Serif", 12);
    VizitKartica.Controls.Add(tb);
    elementi_lista.AddItem(tb.Name);
    VizitKartica.ResumeLayout(true); // Call after adding it to the Controls collection
    tb.MouseMove += new MouseEventHandler(tb_MouseMove);
    tb.MouseDown += new MouseEventHandler(tb_MouseDown);
}
