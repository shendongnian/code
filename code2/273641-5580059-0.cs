    protected string SetPriorityImage(object priority)
    {
        string image = "";
        int prioritySwitch = Convert.ToInt32(priority);
        switch (prioritySwitch )
        {
            case 1: 
                image="~/Images/Red.png";
                break;
            case 5:
                image="~/Images/Green.png";
                break;
            default:
                image="~/Images/Error.png";
                break;
        }
        return image;
    }
