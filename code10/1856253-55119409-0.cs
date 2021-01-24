    TabPage tpOld = tabControl1.SelectedTab;
         TabPage tpNew = new TabPage();
         foreach (Control c in tpOld.Controls)
         {
             Control cNew = (Control)Activator.CreateInstance(c.GetType());
             PropertyDescriptorCollection pdc = TypeDescriptor.GetProperties(c);
             foreach (PropertyDescriptor entry in pdc)
             {
                 object val = entry.GetValue(c);
                 entry.SetValue(cNew, val);
            }
            tpNew.Controls.Add(cNew);
          }
          tabControl1.TabPages.Add(tpNew);
