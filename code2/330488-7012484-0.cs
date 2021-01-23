        private CheckBox _myCustomCheckbox = new CheckBox();
        protected override void OnInit(EventArgs e)
        {
            TableRow tr = new TableRow();
            for (int i = 0; i < 2; i++)
            {
                TableCell Tc = new TableCell();
                if (i == 0)
                {
                    Tc.Attributes["style"] = "line-height: 30px; text-align: left";
                    Tc.Attributes["width"] = "50%";
                    Tc.Style.Add("padding-left", "5px");
                    //Checkboxes on left along with labels
                    _myCustomCheckbox.ID = "checkBoxCtrl" + j;
                    Tc.Controls.Add(_myCustomCheckbox);
                    tr.Cells.Add(Tc);
                }
            }
            // the row needs added to a page control so that the child control states can be loaded 
            SomeTableOnThePage.Controls.Add(tr);
            base.OnInit(e);
        }
        protected void Update2_Click(object sender, EventArgs e)
        {
            if(_myCustomCheckbox.Checked)
            {
                response.write("true");
            }
        }
