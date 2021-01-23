            /// <summary>
        /// determines if a form is on top and really visible.
        /// a problem you ran into is that form.invalidate returns true, even if another form is on top of it. 
        /// this function avoids that situation
        /// code and discussion:
        /// https://stackoverflow.com/questions/4747935/c-sharp-winform-check-if-control-is-physicaly-visible
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        public bool ChildReallyVisible(Control child)
        {
            bool result = false;
            var pos = this.PointToClient(child.PointToScreen(Point.Empty));
            result = this.GetChildAtPoint(pos) == child;
            //this 'if's cause the condition only to be checked if the result is true, otherwise it will stay false to the end
            if(result)
            {
                result = (this.GetChildAtPoint(new Point(pos.X + child.Width - 1, pos.Y)) == child);
            }
            if(result)
            {
                result = (this.GetChildAtPoint(new Point(pos.X, pos.Y + child.Height - 1)) == child);
            }
            if(result)
            {
                result = (this.GetChildAtPoint(new Point(pos.X + child.Width - 1, pos.Y + child.Height - 1)) == child) ;
            }
            return result;
        }
