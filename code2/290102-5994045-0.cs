        /// <summary>
        /// Gets controls.
        /// </summary>
        public override ControlCollection Controls
        {
            get
            {
                EnsureChildControls();
                return base.Controls;
            }
        }
        /// <summary>
        /// Create child controls.
        /// </summary>
        protected override void CreateChildControls()
        {
            this.Controls.Clear();
            //do stuff here e.g.
            LinkButton prevLink = new LinkButton();
            prevLink.Text = "< Prev";
            prevLink.CommandArgument = (PageIndex - 1).ToString();
            prevLink.Command += new CommandEventHandler(PagerLinkCommand);
            this.Controls.Add(prevLink);
        }
        protected void PagerLinkCommand(object sender, CommandEventArgs e)
        {
          PageIndex = int.Parse(e.CommandArgument.ToString());
          EnsureChildControls();
        }        
