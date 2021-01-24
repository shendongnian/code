            private void Suggestion_Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<ComboBox, Panel> CoLi = new Dictionary<ComboBox, Panel>
            {
                { Suggestion_Box1, Suggestion_Panel1 },
                { Suggestion_Box2, Suggestion_Panel2 },
                { Suggestion_Box3, Suggestion_Panel3 },
                { Suggestion_Box4, Suggestion_Panel4 }
            };
            foreach (var i in CoLi)
            {
                if (i.Key.SelectedIndex != -1)
                {
                    i.Key.BackColor = Color.FromName(Used_Colors[i.Key.SelectedIndex]);
                    i.Value.BackColor = Color.FromName(Used_Colors[i.Key.SelectedIndex]);
                }
            }
        }
 
