public string MyProperty {
    get {
        return this.MyProperty;
    }
    set {
        this.MyProperty = value;
    }
}
That is really like having these two methods:
    string get_MyProperty() {
        return get_MyProperty();
    }
    void set_MyProperty(string value) {
        set_MyProperty(value);
    }
You will notice that both cases will result in infinite recursion that will end with a [stack overflow][1].
So Don't Do That™
  [1]: https://en.wikipedia.org/wiki/Stack_overflow
