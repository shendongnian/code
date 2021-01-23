     Private Sub PictureBox1_MouseHover(ByVal sender As Object, _
                       ByVal e As System.EventArgs) Handles PictureBox1.MouseHover
        'PictureBox1 is the thumbnail on the original form.
        'PictureBox2 is the full size image on the popup form.
        Form2.PictureBox2.ClientSize = PictureBox1.Image.Size
        Form2.PictureBox2.Image = CType(PictureBox1.Image.Clone, Image)
        Form2.ShowDialog()
    End Sub
