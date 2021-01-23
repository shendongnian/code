    public class Mk_MessageBox
    {
        public static bool? Show(string title, string text)
        {
            MessageboxNew msg = new MessageboxNew
            {
                TitleBar = {Text = title},
                Textbar = {Text = text}
            };
            msg.noBtn.Focus();
            return msg.ShowDialog();
        }
    }
