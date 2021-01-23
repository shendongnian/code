    string first = @"M&#275;r&#257; n&#257;ma nitina hai";
    first = System.Web.HttpUtility.HtmlDecode(first);
    byte[] ansi = System.Text.Encoding.Convert(Encoding.Unicode, Encoding.GetEncoding(1252), Encoding.Unicode.GetBytes(first));
    string output = Encoding.Unicode.GetString(System.Text.Encoding.Convert(Encoding.GetEncoding(1252), Encoding.Unicode, ansi));
    MessageBox.Show(output);
