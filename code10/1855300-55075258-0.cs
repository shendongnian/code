    private void OnTriggerEnter(Collider collide){
        if (doorLockState == false)
        {
            if (doors != null)
            {
               for(int i =0; i < doors.Count; i++)
                {
                    doors[i].OpenDoor();
                }
            }
        }
    }
