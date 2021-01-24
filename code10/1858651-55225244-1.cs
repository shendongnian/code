    public UnityEngine.UI.Text text;
    string oldTextValue = "";
    bool isHide = true;
    void Update()
    {
        Debug.Log( "Start" );
        if( Input.GetMouseButtonDown( 1 ) )
        {
            Debug.Log( "Pressed Mouse button" );
            if( isHide == true )
            {
                Debug.Log( "Disabling Text" );
                oldTextValue = text.text;
                text.text = "";
                isHide = false;
            }
            else if ( isHide == false ) // Else it wil always just enable the button when u press your mouse.
            {
                Debug.Log( "Enabling Text" );
                text.text = oldTextValue;
                isHide = true;
            }
        }
    }
