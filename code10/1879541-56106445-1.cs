    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEditor;
    public class Tester : MonoBehaviour
    {
    int characterCounter = 0;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Character c = CreateMyAsset();
            c.Initialize("a", "b", "c", true);
        }
    }
    public Character CreateMyAsset()
    {
        Character asset = ScriptableObject.CreateInstance<Character>();
        string assetName = "Assets/c" + characterCounter + ".asset";
        characterCounter++;
        AssetDatabase.CreateAsset(asset, assetName);
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
        return asset;
    }
    
    }
