      public string TextInABox(By by)
      {
        string valueInBox = string.Empty;
        for (int second = 0;; second++) {
          if (second >= 60) Assert.Fail("timeout");
          try
          {
            valueInBox = driver.FindElement(by).value;
            if (string.IsNullOrEmpty(valueInBox) break;
          }
          catch (WebDriverException)
          {}
          Thread.Sleep(1000);
        }
        return valueInBox;
      }
