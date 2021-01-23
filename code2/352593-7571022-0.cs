        private void PopulateResources()
        {
            foreach (Resource res in GetResources(Type))
            {
                ResourceValue.Items.Add(new ListItem(res.Text, SerializeResourceKey(res.Key)));
            }
        }
       
        private void MarkSelectedResources()
        {
            foreach (Resource res in Appointment.Resources.GetResourcesByType(Type))
            {
                ResourceValue.Items.FindByValue(SerializeResourceKey(res.Key)).Selected = true;
            }
        }
