        //recursive
        //This is the simplest implementation, but the most memory hungry
        private IEnumerable<DataObjects.Error> CheckErrors(Control.ControlCollection controls, ErrorProvider errorProvider)
        {
            var errors = new List<DataObjects.Error>();
            foreach (var control in controls.Cast<System.Windows.Forms.Control>())
            {
                //insert your own business logic in here
                var error = errorProvider.GetError(control);
                if (!string.IsNullOrEmpty(error))
                {
                    errors.Add(new DataObjects.Error(error, DataObjects.ErrorLevel.Validation));
                }
                //recursive call
                errors.AddRange(CheckErrors(control.Controls, errorProvider));
                //insert your own business logic in here
            }
            return errors;
        }
        //Breadth first - Does NOT require child node to have knowledge of parent
        //Read through the controls at a given level and then blindly delve 
        //deeper until you reach the end of the rainbow
        //order(max-tree-level-size) memory usage?
        //tree-level-size, as in the # of nodes at a given depth
        private IEnumerable<DataObjects.Error> CheckErrors_NonRecursive_NeverLookBack(Control control, ErrorProvider errorProvider)
        {
            var currentControls = control.Controls.Cast<Control>();
            var errors = new List<DataObjects.Error>();
            while (currentControls.Count() > 0)
            {
                foreach (var currentControl in currentControls)
                {
                    //insert your own business logic in here
                    var error = errorProvider.GetError(currentControl);
                    if (!string.IsNullOrEmpty(error))
                    {
                        errors.Add(new DataObjects.Error(error, DataObjects.ErrorLevel.Validation));
                    }
                    //insert your own business logic in here
                }
                //replace currentControls with ALL of the nodes at a given depth
                currentControls = currentControls.SelectMany(x => x.Controls.Cast<Control>());
            }
            return errors;
        }
        //Depth first - Does NOT require child to have knowledge of parent
        //Approximate recursion by keeping a stack of controls, instead of a call stack.
        //Traverse the stack as you would have with recursion
        //order(tree-branch-size) memory usage? tree-branch-size as in the number of nodes 
        //that it takes to get from the root to the bottom of a given branch
        private IEnumerable<DataObjects.Error> CheckErrors_NonRecursive(Control.ControlCollection controls, ErrorProvider errorProvider)
        {
            var controlStack = new Stack<Control.ControlCollection>();
            var controlIndicies = new Stack<int>();
            var errors = new List<DataObjects.Error>();
            controlStack.Push(controls);
            controlIndicies.Push(0);
            while(controlStack.Count() > 0)
            {
                while(controlIndicies.First() < controlStack.First().Count)
                {
                    var controlIndex = controlIndicies.Pop();
                    var currentControl = controlStack.First()[controlIndex];
                    //insert your own business logic in here
                    var error = errorProvider.GetError(currentControl);
                    if (!string.IsNullOrEmpty(error))
                    {
                        errors.Add(new DataObjects.Error(error, DataObjects.ErrorLevel.Validation));
                    }
                    //insert your own business logic in here
                    //update the fact that we've processed one more control
                    controlIndicies.Push(controlIndex + 1);
                    if(currentControl.Controls.Count > 0)
                    {
                        //traverse deeper
                        controlStack.Push(currentControl.Controls);
                        controlIndicies.Push(0);
                    }
                    //else allow loop to continue uninterrupted, to allow siblings to be processed
                }
                //all siblings have been traversed, now we need to go back up the stack
                controlStack.Pop();
                controlIndicies.Pop();
            }
            return errors;
        }
        //Depth first - DOES require child to have knowledge of parent.
        //Approximate recursion by keeping track of where you are in the control 
        //tree and use the .Parent() and .Controls() methods to traverse the tree.
        //order(depth(tree)) memory usage? 
        //Best of the bunch as far as I can (in memory usage that is)
        private IEnumerable<DataObjects.Error> CheckErrors_NonRecursiveIndicesOnly(Control control, ErrorProvider errorProvider)
        {
            var errors = new List<DataObjects.Error>();
            var controlIndicies = new Stack<int>();
            var controlCount = new Stack<int>();
            Control currentControl = control;
            var currentControls = currentControl.Controls;
            controlCount.Push(currentControls.Count);
            controlIndicies.Push(0);
            while (controlCount.Count() > 0)
            {
                while (controlIndicies.First() < controlCount.First())
                {
                    var controlIndex = controlIndicies.Pop();
                    currentControl = currentControls[controlIndex];
                    //insert your own business logic in here
                    var error = errorProvider.GetError(currentControl);
                    if (!string.IsNullOrEmpty(error))
                    {
                        errors.Add(new DataObjects.Error(error, DataObjects.ErrorLevel.Validation));
                    }
                    //insert your own business logic in here
                    //update the fact that we've processed one more control
                    controlIndicies.Push(controlIndex + 1);
                    if (currentControl.Controls.Count > 0)
                    {
                        //traverse deeper
                        currentControls = currentControl.Controls;
                        controlCount.Push(currentControl.Controls.Count);
                        controlIndicies.Push(0);
                    }
                    else
                    {
                        //allow loop to continue uninterrupted, to allow siblings to be processed
                    }
                }
                //all siblings have been traversed, now we need to go back up the stack
                controlCount.Pop();
                controlIndicies.Pop();
                //need to check our position in the stack... once we get back to the top there is no parent of parent.
                if (controlCount.Count() > 0)
                {
                    currentControls = currentControl.Parent.Parent.Controls;
                }
                //do nothing, believe it or not once you've gotten to this level you have traversed the entire stack
            }
            return errors;
        }
