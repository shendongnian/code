    #if UNITY_EDITOR
    using UnityEditor;
    #endif
    using UnityEngine;
    using UnityEngine.UI;
    
    class Foo : MonoBehaviour
    {
        public Button lastButton;
        public Image[] images;
    }
    
    #if UNITY_EDITOR
    [CustomEditor(typeof(Foo))]
    class FooEditor : Editor
    {
    
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
    
            // fetch current values from the real target into the serialized "clone"
            serializedObject.Update();
    
            Foo foo = (Foo)target;
            if (GUILayout.Button("Bind last Button and all Images"))
            {
                // get last button field as serialized property
                var lastButtonField = serializedObject.FindProperty("lastButton");
    
                // get last Button reference
                // pass true to also get eventually inactive children
                var buttons = foo.GetComponentsInChildren<Button>(true);
                var lastButton = buttons[buttons.Length - 1];
    
                // asign lastButton to the lastButtonField
                lastButtonField.objectReferenceValue = lastButton;
    
    
                // slightly more complex but similar
                // get the field as serialized property
                var imagesField = serializedObject.FindProperty("images");
    
                // get the images references
                // again pass true to also get eventually inactive ones
                var images = foo.GetComponentsInChildren<Image>(true);
    
                // now first set the according list size
                imagesField.arraySize = images.Length;
    
                // assign all references
                for (var i = 0; i < imagesField.arraySize; i++)
                {
                    // serialized property of the element in the field list
                    var entry = imagesField.GetArrayElementAtIndex(i);
    
                    // simply assign the reference like before with the button
                    entry.objectReferenceValue = images[i];
                }
            }
    
            // write back changes to the real target
            // automatically handles marking as dirty and undo/redo
            serializedObject.ApplyModifiedProperties();
        }
    }
    #endif
    
