    using UnityEditor;
    using UnityEngine;
    
    public class HandleNewScriptAndSO : ScriptableObject
    {
        public StringRef ActiveDirectory_Ref;
        public StringRef NewSOName;
        public BoolRef TypeHasBeenAdded_Ref;
    
        private string NewSOPath;
    
        private void OnEnable()
        {
            AssemblyReloadEvents.afterAssemblyReload += GenerateNewSO;
        }
    
        public void GenerateNewSO()
        {
            if (TypeHasBeenAdded_Ref.Val)
            {            
                ScriptableObject NewSO = CreateInstance(NewSOName.Val);
                NewSOPath = ActiveDirectory_Ref.Val + '/' + NewSOName.Val + '/' + NewSOName.Val + ".asset";
                AssetDatabase.CreateAsset(NewSO, NewSOPath);
    
                TypeHasBeenAdded_Ref.Val = false;
            }            
        }        
    }
