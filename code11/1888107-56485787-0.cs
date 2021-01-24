    using System.Runtime.InteropServices;
    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);
    private float horizontalFromArduino;
    private float verticalFromArduino;
    public float sensitivity;
    void Update() 
    {
        float newXPos = Input.mousePosition.x + horizontalFromArduino * sensitivity * Time.deltaTime;
        newXPos = Mathf.Clamp(0,Screen.width);
        float newYPos = Input.mousePosition.y + verticalFromArduino * sensitivity * Time.deltaTime;
        newYPos = Mathf.Clamp(0,Screen.height);
        SetCursorPos(newXPos, newYPos);
    }
