    public static bool IsNewLine(char value) {
      return value == 0x000d        // Carriage return
          || value == 0x000a        // Linefeed
          || value == 0x2028        // Line separator
          || value == 0x2029        // Paragraph separator
      ;
    }
