        public static String HandleDialog(IE ie)
        {
            if (ie.HtmlDialogs.Count > 0)
            {
                HtmlDialog dialog = ie.HtmlDialogs.First();
                String text = dialog.Text;
                ie.HtmlDialogs.CloseAll();
                return text;
            }
            else 
                return "";
        }
