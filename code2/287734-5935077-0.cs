    foreach(Object obj in Room.ChildObjects)
    {
        if(obj is Desk)
        {
            Desk DeskObj = obj as Desk; // Cast the object reference as a desk.
            DeskObj.MaxDraws = 50; // It's a big desk!
            DestObj.Draws[1] = new Draw(); // ......
        }
    }
