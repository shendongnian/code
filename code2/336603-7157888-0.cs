         for (int i = 0; i < a.Length; i++)
        {
            MessageBox.Show(a[i]);
        }
    }
    private string[] a;
    public void button7_Click(object sender, EventArgs e)
    {
         a = new string[]{ textBox1.Text};
    }
