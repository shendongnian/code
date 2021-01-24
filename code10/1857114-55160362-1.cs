    public bool IsGood {
      get {
        // Simplest implementation; often adding a backing field is a good idea
        return label1.Text = string
          .Equals("GOOD", label1.Text, StringComparison.OrdinalIgnoreCase);
      }
      set {
        label1.Text = value ? "GOOD" : "BAD";
      }
    }
