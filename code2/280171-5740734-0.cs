    foreach (var singleDelegate in theEvent.GetInvocationList()) {
       try {
          singleDelgate.DynamicInvoke(new object[] { sender, eventArg });
       } catch (Exception ex) {
          // uck
       }
    }
