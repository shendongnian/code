    private void getListOfDiv(string html, string classname)
    {
        if (html != null)
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            var divProduktkategorie = doc.DocumentNode.SelectSingleNode("//div[@class='" + classname + "'//div[@class='dealer-offer']]");
            //this.txtHtmlCode.Text = divProduktkategorie.InnerHtml;
            //return;
            int i = 1;
            foreach( var divAngebote in divProduktkategorie)
            {
                this.listBox1.Items.Add(i + ": " + classname);
                this.txtHtmlCode.AppendText(divAngebote.OuterHtml);
                i++;
            }
        }
    }
