    using System.Security.Cryptography;
    using System.Text;
    
    private static string MD5(string Metin)
    {
        MD5CryptoServiceProvider MD5Code = new MD5CryptoServiceProvider();
        byte[] byteDizisi = Encoding.UTF8.GetBytes(Metin);
        byteDizisi = MD5Code.ComputeHash(byteDizisi);
        StringBuilder sb = new StringBuilder();
        foreach (byte ba in byteDizisi)
        {
            sb.Append(ba.ToString("x2").ToLower());
        }
        return sb.ToString();
    }
    
    MessageBox.Show(MD5("isa")); // 165a1761634db1e9bd304ea6f3ffcf2b
