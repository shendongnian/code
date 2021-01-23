        private void button1_Click(object sender, EventArgs e)
        {
            /// get all of the controls in the form's hierarchy in a List<>
            var controlList = GetControlHierarchy(this).ToList();
            foreach (var control in controlList)
            {
                /// do something with this control
            }
        }
