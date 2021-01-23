        private void button1_Click(object sender, EventArgs e)
        {
            /// get all of the controls in the form's hierarchy in a List<>
            foreach (var control in GetControlHierarchy(this))
            {
                /// do something with this control
            }
        }
