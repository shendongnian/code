    using System;
    
    partial class Person : IEquatable<Person> {
      public Person(string firstName, string lastName, int age = 18) {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
      }
    
      private bool ImmutableEquals(Person obj) {
        if (ReferenceEquals(this, obj)) return true;
        if (ReferenceEquals(obj, null)) return false;
        return T4Immutable.Helpers.AreEqual(this.FirstName, obj.FirstName) && T4Immutable.Helpers.AreEqual(this.LastName, obj.LastName) && T4Immutable.Helpers.AreEqual(this.Age, obj.Age);
      }
    
      public override bool Equals(object obj) {
        return ImmutableEquals(obj as Person);
      }
    
      public bool Equals(Person obj) {
        return ImmutableEquals(obj);
      }
    
      public static bool operator ==(Person a, Person b) {
        return T4Immutable.Helpers.AreEqual(a, b);
      }
    
      public static bool operator !=(Person a, Person b) {
        return !T4Immutable.Helpers.AreEqual(a, b);
      }
    
      private int? _ImmutableHashCode;
    
      private int ImmutableGetHashCode() {
        if (_ImmutableHashCode == null) _ImmutableHashCode = new { this.FirstName, this.LastName, this.Age }.GetHashCode();
        return _ImmutableHashCode.Value;
      }
    
      public override int GetHashCode() {
        return ImmutableGetHashCode();
      }
    
      private string ImmutableToString() {
        var sb = new System.Text.StringBuilder();
        sb.Append(nameof(Person) + " { ");
    
        var values = new string[] {
          nameof(this.FirstName) + "=" + T4Immutable.Helpers.ToString(this.FirstName),
          nameof(this.LastName) + "=" + T4Immutable.Helpers.ToString(this.LastName),
          nameof(this.Age) + "=" + T4Immutable.Helpers.ToString(this.Age),
        };
    
        sb.Append(string.Join(", ", values) + " }");
        return sb.ToString();
      }
    
      public override string ToString() {
        return ImmutableToString();
      }
    
      private Person ImmutableWith(T4Immutable.WithParam<string> firstName = default(T4Immutable.WithParam<string>), T4Immutable.WithParam<string> lastName = default(T4Immutable.WithParam<string>), T4Immutable.WithParam<int> age = default(T4Immutable.WithParam<int>)) {
        return new Person(
          !firstName.HasValue ? this.FirstName : firstName.Value,
          !lastName.HasValue ? this.LastName : lastName.Value,
          !age.HasValue ? this.Age : age.Value
        );
      }
    
      public Person With(T4Immutable.WithParam<string> firstName = default(T4Immutable.WithParam<string>), T4Immutable.WithParam<string> lastName = default(T4Immutable.WithParam<string>), T4Immutable.WithParam<int> age = default(T4Immutable.WithParam<int>)) {
        return ImmutableWith(firstName, lastName, age);
      }
    
    }
