    Type enumType = gender.GetType();
    bool isEnumValid = Enum.IsDefined(enumType, gender);
    if (!isEnumValid) {
      throw new Exception("...");
    }
