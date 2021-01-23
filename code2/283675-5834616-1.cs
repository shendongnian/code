    void HandleRequest() {
      try {
        Response.Redirect(...);
      }
      catch (Exception ex) {
        Response.Write(...);
      }
    }
