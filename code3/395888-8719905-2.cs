    public ReadOnlyCollection<Character> Characters {
      get {
        lock (locker) { return this.characters.AsReadOnly(); }
      }
    }
