    PowerProjectDBLinqDataContext dataContext =new PowerProjectDBLinqDataContext();
                IEnumerable<Winding_Building_typeCombo> ls = dataContext.Winding_Building_typeCombos.ToList();
                ComboBox cbx;
               for (int i = 1; i <= windingCount; i++)
               {
                   IEnumerable<Winding_Building_typeCombo> lsCopy = new List<Winding_Building_typeCombo>(ls);
                   cbx=((ComboBox)WindingPanel.Controls["winding" + i].Controls["cbxWindingBildingType" + i]);
                   cbx.DataSource = lsCopy;
                   lsCopy = null;
                   cbx.ValueMember = "id";
                   cbx.DisplayMember = "value";
               }
***
