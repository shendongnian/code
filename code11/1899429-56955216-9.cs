    private bool pressed;
    private bool hovered;
    ...
    public void OnGUI()
    {
        var color = GUI.color;
        var rect = new Rect(...);
        var ev = Event.current;
        hovered = ev.mousePosition.x > rect.x && ev.mousePosition.x < rect.x + rect.width && ev.mousePosition.y > rect.y && ev.mousePosition.y < rect.y + rect.height;
        if (Event.current.type == EventType.MouseUp) pressed = false;
        else if (ev.type == EventType.MouseDown) pressed = true;
        if (hovered && pressed) GUI.color = Color.green;
        if (GUI.Button(rect, ...))
        {
            ...
        }
        GUI.color = color;
        // in order to receive the mouse events
        Repaint();
    }
