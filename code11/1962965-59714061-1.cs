        // Create a field with slabs as an instance variable on your editting form
        private List<Slab> allSlabs = new List<Slab>();
        public void Click_ButtonSaveNewSlab()
        {
            // check if we should save it
            if (txtMaterial.Text.Length > 0)
            {
                // Our new slab
                Slab s = new Slab(txtThickness.Text, txtMaterial.Text, txtBatch.Text);
                // Add the new slab to the list
                allSlabs.Add(s);
            }
        }
        public void Click_ButtonSendHtml()
        {
            // Some HTML string to append to
            string html = "<h1>Hello Slabs</h1>";
            // Whenever we want to do something for every slab in the list use foreach
            foreach (Slab s in allSlabs)
            {
                // Add every Slab's data to the HTML
                html += $"<h6> Material: {s.Material} </h6>";
            }
            // Whenever we want to do something with every slab in the list and use it's position counter aswell use for
            for (int i = 0; i < allSlabs.Count; i++)
            {
                // Grab a Slab from the list specified by the counter i
                Slab s = allSlabs[i];
                // Add every Slab's data to the HTML
                html += $"<h6> ID: {i}  Material: {s.Material} </h6>";
            }
            // Also look into LINQ for drilling down into lists and selecting subsets
            var allBedrockSlabs = allSlabs.Where(slab => slab.Material == "Bedrock");
            foreach(Slab bedrockSlab in allBedrockSlabs)
            {
                //etc ... 
            }
        }
