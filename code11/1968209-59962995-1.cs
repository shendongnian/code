csharp
//top-level property
myClass.SetPropertyAsString("num", "88");
//nested properties
myClass.SetPropertyAsString("member:side:include", "true");
myClass.SetPropertyAsString("part:seriesNum", "15");
Then modify the reflection code so it can go down a given path:
csharp
//will handle both nested and top-level properties
public static void SetPropertyAsString(this IMPropertyAsStringSettable self, string propertyName, string value) {
    //current, is in a way, the property iterator
    var current = self;
    var keys = propertyName.Split(":");
    //iterate over keys till the key before last -since the last key is the target property-
    foreach (var key in keys[0..^1]) {
        var property = current.GetType().GetProperty(key);
        current = property.GetValue(current) as IMPropertyAsStringSettable;
    }
    var targetProperty = current.GetType().GetProperty(keys.Last());
    //convert the input value to the data type of the target property, and set it to the target property
    targetProperty.SetValue(current, Convert.ChangeType(value, targetProperty.PropertyType));
}
---
**EDIT: for C# < 8.0**
Based on your comments, you're using C# version < 8.0 where some of the features used in the original response aren't available (like the range operator `^`). I have compiled the following on `.NET 4.7.2`, `C# 7.3` and produced the same result.
csharp
public static void SetPropertyAsString(this IMPropertyAsStringSettable self, string propertyName, string value) {
    var current = self;
    var keys = propertyName.Split(':');
    for (var i = 0; i < keys.Length - 1; i++) {
        var property = current.GetType().GetProperty(keys[i]);
        current = property.GetValue(current) as IMPropertyAsStringSettable;
    }
    var targetProperty = current.GetType().GetProperty(keys[keys.Length - 1]);
    targetProperty.SetValue(current, Convert.ChangeType(value, targetProperty.PropertyType));
}
