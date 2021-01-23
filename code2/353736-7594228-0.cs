    public class ComboboxSwitcher
    {
        List<ComboBox> boxlist = new List<ComboBox>();
        Dictionary<ComboBox, object> olditems = new Dictionary<ComboBox, object>();
        public void Add(params ComboBox[] boxes)
        {
            boxlist.AddRange(boxes);
            boxes.ToList().ForEach(box => box.SelectedIndexChanged += handler);
        }
        private void handler(object sender, EventArgs e)
        {
            ComboBox trigger = (ComboBox) sender;
            object item = trigger.SelectedItem;
            object olditem = null;
            if (olditems.ContainsKey(trigger)) olditem = olditems[trigger];
            boxlist.ForEach(box =>
                                {
                                    if (box != trigger)
                                    {
                                        if (olditem != null) box.Items.Add(olditem);
                                        box.Items.Remove(item);
                                    }
                                });
            olditems[trigger] = item;
        }
    }
