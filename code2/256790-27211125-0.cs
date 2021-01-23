        private void button1_Click(object sender, EventArgs e)
        {
            // Reference Microsoft.Office.Interop.Word
            // using System;
            // using System.IO;
            // using System.Windows.Forms;
            // using Microsoft.Office.Interop.Word; 
            MessageBox.Show(GetEmailAddress("C:\\Sample.docx"));
        }
        private string GetEmailAddress(string file)
        {
            string emails = "";
            // Open a doc file.
            Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
            Document document = application.Documents.Open(file);
            // Loop through all words in the document.
            int count = document.Words.Count;
            for (int i = 1; i <= count; i++)
            {
                // Write the word.
                string text = document.Words[i].Text;
                //Extract Emails
                if (document.Words[i].Text.Contains("@"))
                {
                    emails += document.Words[i - 1].Text + text + document.Words[i + 1].Text + "; ";
                }
            }
            // Close word.
            application.Quit();
            return emails;
        }
    }
