      private void dropdownbox1_SelectedIndexChanged(object sender, EventArgs e)
      {
            selected = dropdownbox1.Text;
            if (selected == "First Option In Box1")
            {
                dropdownbox2.Items.Clear();
                dropdownbox2.Items.AddRange(new string[] { "First Option", "Second Option", "Third Option" });
            }
            if (selected == "Second Option In Box1")
            {
                dropdownbox2.Items.Clear();
                dropdownbox2.Items.AddRange(new string[] { "First Option", "Second Option", "Third Option" });
            }
      }
