    public async Task<string> CallNewGetKeyboard(UsernameRectangle userRec, bool CheckButtonPressed, string tokenUserName, string messageBoxTitle, string messageBoxDescription, string messageBoxText, bool isPassword)
    {
        if ((userRec.Intersects(CursorRectangle)) && (CheckButtonPressed == true))
        {
            var KeyboardTextUsername = await NewGetKeyboard(tokenUsername, messageBoxTitle, messageBoxDescription, messageBoxText, isPassword);
            return KeyboardTextUsername;    
        }
    }
