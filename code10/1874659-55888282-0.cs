public Form2 f;
public void BtnSearch_Click(object sender, EventArgs e)
{
    if (f == null || f.IsDisposed || f.Disposing) f = new Form2(...);
    f.Show();
}
