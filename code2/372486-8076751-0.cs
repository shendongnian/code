     class myMessageBox
        {
            private myMessageBox()
            { }
    
            public static void Show(string text,params object[] i)
            {
                text = String.Format(text, i);
                MessageBox.Show(text);
            }
        }
