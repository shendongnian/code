        RichTextBox RichTextBox1 = new RichTextBox();
        public static string RemoveRTF(string input)
                {
        
        string output = input;
                    
        try {
                        RichTextBox1.Rtf = input;
                        output = RichTextBox1.Text;
    RichTextBox1.rtf = null;
                    } catch (ArgumentException argExp) { 
                        /*
                         * The supplied input value is not in RTF format. 
                         * Ignore.
                         */
                    }
                    return output;
                }
