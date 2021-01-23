    private void btnConvert_Click(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Parse(txtXml.Text);
            ProcessElement(doc.Elements().First());
            txtXml.Text = doc.ToString(SaveOptions.DisableFormatting);
        }
        private void ProcessElement(XElement element)
        {
            if (element.HasElements)
                element.Elements().ToList().ForEach(e => ProcessElement(e));
            else
                element.Value = element.Value.ToUpper();
        }
