          public static String AddNewLineCharsToMessage(TextBox textBox)
      {
         String message = String.Empty;
         if (textBox == null) return message;
         // Just assign the text if we have a single line message
         if (textBox.LineCount < 2)
            return textBox.Text;
         // Find the index for the first line that contains text displayed in the TextBox.
         // GetLineText(index) will return the text displayed/entered by the user for indices less
         // than the index of the line that the text is actually displayed on.  This seems to be
         // a bug to me, but I will workaround this Microsoft weirdness.
         // Find the index of first line that actually displays text by using the length of TextBox.Text
         Int32 firstTextLineIndex = 0;
         Int32 textLen = textBox.Text.Length;
         Int32 textLinesLen = 0;
         for (Int32 firstTextLine = textBox.LineCount - 1; firstTextLine >= 0; firstTextLine--)
         {
            textLinesLen += textBox.GetLineText(firstTextLine).Length;
            if (textLinesLen >= textLen)
            {
               firstTextLineIndex = firstTextLine;
               break;
            }
         }
            
         // First strip all the carriage returns and newline characters
         // so we don't have duplicate newline characters in the message.
         // Then add back in just the newline characters which is what the car
         // code uses to parse out the message to be displayed on each line.
         var textLines = new List<string>(5);
         int lineCount = Math.Min(textBox.LineCount, textBox.MaxLines);
         for (Int32 index = 0; index < lineCount; index++)
         {
            if (index < firstTextLineIndex)
               textLines.Add("");
            else  // if (textBox.GetLineText(index).Length > 0)
            {
               textLines.Add(textBox.GetLineText(index));
               textLines[index] = textLines[index].Replace("\r", "");
               textLines[index] = textLines[index].Replace("\n", "");
            }
         }
         message = String.Empty;
         for (Int32 index = 0; index < lineCount; index++)
            message += textLines[index] + (index < lineCount - 1 ? "\n" : "");
         return message;
      }
