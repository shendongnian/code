    EventInput.CharEntered += HandleCharEntered;
    public void HandleCharEntered(object sender, CharacterEventArgs e)
    {
        var charEntered = e.Character;
        // Do something with charEntered
    }
