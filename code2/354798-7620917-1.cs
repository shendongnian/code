    private ButtonType buttonType; // public variables usually aren't a good idea
    public void ChangeButtonType(ButtonType type)
    {
        button1.Image = type.GetImage();
        buttonType = type;
    }
