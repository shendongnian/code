    //if up arrow is pressed  animation stored in Spin will play
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //setting idle to false to ensure it will not execute while spin is executing.
            isIdle = false;
            //setting cheer to false to ensure it will not execute while spin is executing.
            cheer = false;
            //setting spin to true.
            spin = true;
            skip = false;
            // playing animation for miffy to spin.
            anim.Play("SpinJump", 0, 0f);
            //testing if input is working by outputting text "working" to console.
            Debug.Log("Working");
        }
        ////if space has been pressed animation stored in Cheer with play
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //setting idle to false to ensure it will not execute while cheer is executing.
            isIdle = false;
            //setting spin to false to ensure it will not execute while cheer is executing.
            spin = false;
            //setting cheer to true.
            cheer = true;
            skip = false;
            // playing animation for miffy to cheer.
            anim.Play("Cheer", 0, 0f);
            //testing if input is working by outputting text "working" to console.
            Debug.Log("Working");
        }
