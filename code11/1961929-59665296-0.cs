    bool steeringLeft, steeringRight;
    public void OnLeftPointerEnter(BaseEventData data)
    {
        steeringLeft = true;
    }
    public void OnLeftPointerExit(BaseEventData data)
    {
        steeringLeft = false;
    }
    public void OnRightPointerEnter(BaseEventData data)
    {
        steeringRight = true;
    }
    public void OnRightPointerExit(BaseEventData data)
    {
        steeringRight = false;
    }
