    Stack<Button> DynamicButtonStack { get; set; } = new Stack<Button>();
    private void button1_Click_7(object sender, EventArgs e)
    {
        // Your Create Dynamic Button code goes here
        // ...
        //Add latest button to stack
        DynamicButtonStack.Push(btn);
    }
    private void deletebutton_Click(object sender, EventArgs e)
    {
        //If any dynamic buttons exist, remove the most recently added
        if (DynamicButtonStack.Count > 0)
            Controls.Remove(DynamicButtonStack.Pop());
    }
