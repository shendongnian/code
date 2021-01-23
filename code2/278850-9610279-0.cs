        /// <summary>
        /// If a child ToolStripStatusLabel is wider than it's parent then this method will attempt to
        /// make the child's text fit inside of the parent's boundaries. An ellipsis can be appended
        /// at the end of the text to indicate that it has been truncated to fit.
        /// </summary>
        /// <param name="child">Child ToolStripStatusLabel</param>
        /// <param name="parent">Parent control where the ToolStripStatusLabel resides</param>
        /// <param name="appendEllipsis">Append an "..." to the end of the truncated text</param>
        public static void TruncateChildTextAccordingToControlWidth(ToolStripStatusLabel child, Control parent, bool appendEllipsis)
        {
            //If the child's width is greater than that of the parent's
            if(child.Size.Width > parent.Size.Width)
            {
                //Get the % that the child is oversized [parent/child]
                decimal decOverSized = (decimal)(parent.Size.Width) / (decimal)(child.Size.Width);
                
                //Get the new Text length based on the percentage and the magic number 12% which is
                //for a protected buffer.
                int intNewLength = (int)(child.Text.Length * (decOverSized - 0.12M));
                //If the ellipsis is to be appended
                if(appendEllipsis) //then 3 more characters need to be removed to make room for it.
                    intNewLength = intNewLength - 3;
                //If the new length is negative for whatever reason
                if(intNewLength < 0) 
                    intNewLength = 0; //Then default it to zero
                //Truncate the child's Text accordingly
                child.Text = child.Text.Substring(0, intNewLength);
                //If the ellipsis is to be appended
                if(appendEllipsis) //Then do this last
                    child.Text += "...";
            }
        }
