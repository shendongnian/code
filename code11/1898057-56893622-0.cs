    //Keys for controlling the player (move and shoot) only when he's alive
    if (Input.GetKey(KeyCode.UpArrow) && alive)
    {
      GetComponent<Rigidbody>().MovePosition(transform.position + Vector3.forward * Time.deltaTime * 4);
    }
    if (Input.GetKey(KeyCode.DownArrow) && alive)
    {
     GetComponent<Rigidbody>().MovePosition(transform.position + Vector3.back * Time.deltaTime * 4);
    }
