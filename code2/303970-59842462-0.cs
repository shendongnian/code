  MyClass varClass = new MyClass();
  varClass.propObjectProperty = new { Id = 1, Description = "test" };
  var varObjectProperty = ((dynamic)varClass).propObjectProperty;
  ((dynamic)varClass).propObjectProperty = new { Id = varObjectProperty.Id, Description = varObjectProperty.Description, NewDynamicProperty = "new dynamic property description" };
With this approach, you basically rewrite the object property adding or removing properties as if you were first creating the object with the
new { ... }
syntax.
In your particular case, you're probably better off creating an actual object to which you assign properties like "dob" and "address" as if it were a person, and at the end of the process, transfer the properties to the actual "Person" object.
