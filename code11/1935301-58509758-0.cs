    public static TextElement Find(this ArrayTextElement<TextElement> list, Func<string, bool> predicate)
    {
        try
        {
            return list.Items.First(item => predicate(item.Text));
        }
        catch (Exception)
        {
            throw new NotFoundException($"Requested element with text: '{text}' wasn't found.");
        }
    }
