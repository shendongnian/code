            string chatnaam = txtNaam.Text;
            string chatbericht = txtBericht.Text;
            txtblock1.Inlines.Add(new Bold(new Run(chatnaam )));
            txtblock1.Inlines.Add(" says: ");
            txtblock1.Inlines.Add(Environment.NewLine);
            txtblock1.Inlines.Add(Environment.NewLine);
            chatbericht = chatbericht.Replace("Dipshit", "****"); // the change
            txtblock1.Inlines.Add(chatbericht);
            txtblock1.Inlines.Add(Environment.NewLine);
            txtblock1.Inlines.Add(Environment.NewLine);
