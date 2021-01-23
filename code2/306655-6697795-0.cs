    // Member Variables
    // collection of button groups
    private readonly ReadOnlyCollection<ReadOnlyCollection<ToolStripButton>> mGroups;
    // an individual button group
    private readonly ReadOnlyCollection<ToolStripButton> mGroup;    
    // in constructor (after your InitializeComponent call)
    // add controls to this list as needed
    mGroup = new List<ToolStripButton>()
    {
       mButton1,
       mButton2,
       mButton3,
       mButton4
    }.AsReadOnly();
    // add new groups to this list as needed
    mGroups = new List<ReadOnlyCollection<ToolStripItem>>
    {
       mGroup
    }.AsReadOnly();
    // all your buttons click events should hook this method
    private void mToolButton_Click(object sender, EventArgs e)
    {
       foreach(ReadOnlyCollection<ToolStripButton> group in mGroups)
          if (group.Contains(sender))
             foreach (ToolStripButton b in group)
                b.Checked = b == sender;
    }
