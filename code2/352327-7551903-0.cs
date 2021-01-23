    public void PlaySound()
    {
     Game1 newGame; //like assuming that with this you are pointing to the instance of Game1 that it's running and since it's not the instance of that class and it's not even initialized there is the NullReferenceException.....(I think)
    newGame.NewSound.Play(); //Assuming againt that we have a property to access the NewSound
    }
