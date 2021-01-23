        public List<Control> FindAllControls(Control container)
        {
            List<Control> controlList = new List<Control>();
            FindAllControls(container, controlList);
            return controlList;
        }
        private void FindAllControls(Control container, IList<Control> ctrlList)
        {
            foreach (Control ctrl in container.Controls)
            {
                if (ctrl.Controls.Count == 0)
                    ctrlList.Add(ctrl);
                else
                    FindAllControls(ctrl, ctrlList);
            }
        }
