        /// <summary>
        /// (In/De)creases a height of the «control» and the window «form», and moves accordingly
        /// down or up an elements in the «move_list». To decrease size you have to give a negative
        /// argument in the «the_sz».
        /// Usually used to collapse (or expand) an elements of a form, and to move the controls of
        /// the «move_list» down to fill an appeared gap.
        /// </summary>
        /// <param name="control">control to collapse/expand</param>
        /// <param name="form">form which would be resized accordingly after size of a control
        /// changed (give «null» if you don't want to)</param>
        /// <param name="move_list">A list of a controls that should also be moved up or down to
        /// «the_sz» size (e.g. to fill a gap after the «control» collapsed)</param>
        /// <param name="the_sz">size to change the control, form, and the «move_list»</param>
        public static void ToggleControlY(Control control, Form form, List<Control> move_list, int the_sz)
        {
            //→ Change sz of ctrl
            control.Height += the_sz;
            //→ Change sz of Wind
            if (form != null)
                form.Height += the_sz;
            //*** We leaved a gap(or intersected with another controls) now!
            //→ So, move up/down a list of a controls
            foreach (Control ctrl in move_list)
            {
                Point loc = ctrl.Location;
                loc.Y += the_sz;
                ctrl.Location = loc;
            }
        }
