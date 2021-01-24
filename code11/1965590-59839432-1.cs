    bool held = false;
    Update()
    {
        if(held)
        {
            //animation
        }
        else if(!held)
        {
            //idle animation
         }
    }
    OnAttack() {
        held = !held;
    }
