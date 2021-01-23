      Regex driveCheck = new Regex(@"^[a-zA-Z]:\\$");
      if (string.IsNullOrWhiteSpace(path) || path.Length < 3)
      {
        return false;
      }
      if (!driveCheck.IsMatch(path.Substring(0, 3)))
      {
        return false;
      }
      var x1 = (path.Substring(3, path.Length - 3));
      string strTheseAreInvalidFileNameChars = new string(Path.GetInvalidPathChars());
      strTheseAreInvalidFileNameChars += @":?*";
      Regex containsABadCharacter = new Regex("[" + Regex.Escape(strTheseAreInvalidFileNameChars) + "]");
      if (containsABadCharacter.IsMatch(path.Substring(3, path.Length - 3)))
      {
        return false;
      }
      var driveLetterWithColonAndSlash = Path.GetPathRoot(path);
      if (!DriveInfo.GetDrives().Any(x => x.Name == driveLetterWithColonAndSlash))
      {
        return false;
      }
      return true;
    }
