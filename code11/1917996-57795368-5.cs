    if (Input.GetKey(KeyCode.RightArrow))
    {
        Bola.MovePosition(Bola.position + Vector2.right * movdir * Time.deltaTime);
    }
    if (Input.GetKey(KeyCode.LeftArrow))
    {
        Bola.MovePosition(Bola.position + Vector2.right * moveesq * Time.deltaTime);
    }
