using System;
using UnityEngine;
public enum IngredientUnit { Spoon, Cup, Bowl, Piece }
// Custom serializable class
[Serializable]
public class Ingredient
{
    public string name;
    public int amount = 1;
    public IngredientUnit unit;
}
public class Recipe : MonoBehaviour
{
    public Ingredient potionResult;
    public Ingredient[] potionIngredients;
}
[CustomPropertyDrawer(typeof(Ingredient))]
public class IngredientDrawerUIE : PropertyDrawer
{
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        // Create property container element.
        var container = new VisualElement();
        // Create property fields.
        var amountField = new PropertyField(property.FindPropertyRelative("amount"));
        var unitField = new PropertyField(property.FindPropertyRelative("unit"));
        var nameField = new PropertyField(property.FindPropertyRelative("name"), "Fancy Name");
        // Add fields to the container.
        container.Add(amountField);
        container.Add(unitField);
        container.Add(nameField);
        return container;
    }
}
So when you view a GameObject with the `Recipe` component on it, Unity's inspector will show something like this:
[![enter image description here][1]][1]
So you do not need to inherit from anything, simply mark the class you want to create a property drawer as `Serializable`, and create a property drawer class for it (Make sure to place it in the `Editor` folder, or create a assembly definition file which targets the editor only if you are working with assembly definition files).
  [1]: https://i.stack.imgur.com/6Bdqe.png
