    void start() {
        Button btn = ImageButton1.GetComponent<Button>();
        btn.onClick.AddListener(() => TaskOnClick(btn.Name)); // or TaskOnClick(ImageButton1.Name)
    }
    void TaskOnClick(string buttonName)
    {
        Debug.Log ($"You have clicked the button {buttonName}");
    }
