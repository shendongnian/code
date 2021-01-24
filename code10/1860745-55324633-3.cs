        if (isPanning)
        {
            Vector2 mousePosition = Camera.GetMouse(currMousePos);
            Console.WriteLine(mousePosition);                
            DrawLine(SpriteBatch, Camera.CenterScreen, mousePosition, Color.White);
        }
