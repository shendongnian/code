            IHTMLDocument2 htmlDocument = browser.Document.DomDocument as IHTMLDocument2;
            IHTMLSelectionObject sel = (IHTMLSelectionObject)htmlDocument.selection;
            IHTMLTxtRange tr = (IHTMLTxtRange)sel.createRange() as IHTMLTxtRange;
            string s = textBoxFindData.Text;
            if (tmprange == null)
            {
                tr.collapse(Collapse);
                tmprange = tr;
                tr.findText(s, Direction, 0); // positive value, should search forward, negative backward
                if (tr.text == null)
                {
                    MessageBox.Show("Can not find string " + "[" + s + "]", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                tr.select();
            }
            else
            {
                tmprange.collapse(Collapse);
                tmprange.findText(s, Direction, 0); // positive value, should search forward, negative backward
                if (tmprange.text == null)
                {
                    MessageBox.Show("Can not find string " + "[" + s + "]", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                tmprange.select();
            }
        }
        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            Find(-1, true);
        }
