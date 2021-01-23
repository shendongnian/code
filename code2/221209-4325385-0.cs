    // Creates a new label if necessary, and sets the text to Stuff
    public void Foo(ref Label label)
    {
        if (label == null)
        {
            label = new Label();
        }
        label.Text = "Stuff";
    }
