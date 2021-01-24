      if (GUILayout.Button("Add") && NewSOName_Ref.Val != "")
      {
        AssetDatabase.CreateFolder(ActiveDirectory_Ref.Val, NewSOName_Ref.Val);
    
        TemplateLines = File.ReadAllLines("E:/Unity/Editor/Data/Resources/ScriptTemplates/NewScriptableObject.cs.txt");
    
        for (int i = 0; i < TemplateLines.Length; i++)
        {
          if (TemplateLines[i].Contains("#SCRIPTNAME#"))
          {
            TemplateLines[i] = TemplateLines[i].Replace("#SCRIPTNAME#", NewSOName_Ref.Val);
          }
        }
    
        NewFilePath = ActiveDirectory_Ref.Val + '/' + NewSOName_Ref.Val + '/' + NewSOName_Ref.Val + ".cs";
                
        File.WriteAllLines(NewFilePath, TemplateLines);
    
        TypeHasBeenAdded_Ref.Val = true;
                
        AssetDatabase.Refresh();
                
      }
