     private void GetTextFromDroppetFile(DragEventArgs e)
        {
            //Die RichTextBox wird hier erstmal gecleart
            RichTextBoxForOpenText.Document.Blocks.Clear();
            
            string[] filenames = e.Data.GetData(System.Windows.DataFormats.FileDrop) as string[];
            foreach (var name in filenames)
            {
                
                RichTextBoxForOpenText.AppendText(File.ReadAllText(name));
            }
        }
