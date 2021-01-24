    // Either reference those in the Inspector
    public Text roomTypeText;
    public Text roomQtyText;
    private void Awake()
    {
        // or get them on runtime e.g. using Find with the GameObjects' names
        roomTypeText = Find("Room_Type").GetComponent<Text>();
        roomQtyText= Find("Room_Qty").GetComponent<Text>();
    }
    ...
    roomTypeText.text = newRoomData.Room_Type;
    roomQtyText.text = newRoomData.Room_Qty;
