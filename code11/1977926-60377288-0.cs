MemoryStream ms = new MemoryStream();
pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
byte[] img = ms.ToArray();
if (img == null)
{
     com.Parameters.AddWithValue("@img", null);
}
else
{
     com.Parameters.AddWithValue("@img", img);
}
To this
MemoryStream ms = new MemoryStream();
pictureBox1?.Image?.Save(ms, pictureBox1?.Image?.RawFormat);
byte[] img = ms.ToArray();
com.Parameters.AddWithValue("@img", img ?? DBNull.Value);
