      var versionString = new StringBuilder();
      versionString.Append("0x");
      for (var i = 0; i < binary.Count(); i++)
      {
          versionString.Append(string.Format("{0:X}", binary[i]));
      }
      versionString.ToString(); // result
