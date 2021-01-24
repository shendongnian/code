    public static TextElement Find(this ArrayTextElement<TextElement> list, string text, bool exactMatch)
    {
        try
        {
            return list.Items.First(item => exactMatch ? 
                item.Text.Equals(text) :
                item.Text.Contains(text)
             );
        }
        catch (Exception)
        {
            throw new NotFoundException($"Requested element with text: '{text}' wasn't found.");
        }
    }
