    Stack<Action> undoStack = new Stack<Action>();    
    
    void ChangeColor(Color color)
    {
        var original = this.Object.Color;
        undoStack.Push(() => this.Object.Color = original);
        this.Object.Color = color;
    }
