        private static void recolorListItems(ListView lv) {
            for (int ix = 0; ix < lv.Items.Count; ++ix) {
                var item = lv.Items[ix];
                item.BackColor = (ix % 2 == 0) ? Color.Beige : Color.White;
            }
        }
