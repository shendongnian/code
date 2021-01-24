    public Page ServePage() // No async
    {
      #pragma warning disable 4014 //   warning is suppresed by the Pragma
      DoThings(10);   // Kick off DoThings but don't wait for it to complete.
      #pragma warning enable 4014
    
      // ... other code
      return new Page();
    }
