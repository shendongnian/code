    public void continuebut()
    {
        campos = 0;
        campos = transform.position.y;
    
        if (campos >0)
        {
            // If camera position is positive
            // Decrease camera y position
            campos -= 4;//positive y position so the result will decrease the y position
            //Translate camera position
            transform.Translate(0, campos, 0);
        }
        else 
        {
            // If camera position if negative or zero
            // Increase camera y position
            campos += 4;//negative y position so the result will increase the y position
            //Translate camera position
            transform.Translate(0, campos, 0);
        }
    
    }
