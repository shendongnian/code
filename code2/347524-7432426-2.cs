      var ignoreList = new Dictionary<PinInformation, List<string>>();
      ....
      void AddPinToIgnoreList(PinInformation info, string pin)
      {
            if (!ignoreList.ContainsKey(info)) //this is why we override Equals
            {
                 ignoreList.Add(info, new List<string>());
            }
            ignoreList[info].Add(pin);
      }
      void RemovePinFromIgnoreList(PinInformation info, string pin)
      {
            ignoreList[info].Remove(pin);
      }
