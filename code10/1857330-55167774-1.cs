    public async void AddEmojiImpl(string emoji)
    {
        try 
        {
            await AddEmojiImpl(emoji);
        }
        catch (EmojiAddException e)
        {
            // ...
        }
    }
