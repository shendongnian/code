    using System;
    using System.Text;
    using Microsoft.Xna.Framework.Graphics;
    public static float StringWidth(SpriteFont font, string text)
    {
        return font.MeasureString(text).X;
    }
    public static string WrapText(SpriteFont font, string text, float lineWidth)
    {
        const string space = " ";
        string[] words = text.Split(new string[] { space }, StringSplitOptions.None);
        float spaceWidth = StringWidth(font, space),
            spaceLeft = lineWidth,
            wordWidth;
        StringBuilder result = new StringBuilder();
        foreach (string word in words)
        {
            wordWidth = StringWidth(font, word);
            if (wordWidth + spaceWidth > spaceLeft)
            {
                result.AppendLine();
                spaceLeft = lineWidth - wordWidth;
            }
            else
            {
                spaceLeft -= (wordWidth + spaceWidth);
            }
            result.Append(word + space);
        }
        return result.ToString();
    }
