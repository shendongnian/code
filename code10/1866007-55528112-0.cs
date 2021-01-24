    for (var i = selection.Count - 1; i >= 0; --i)
    			{
    				var selected = selection[i];
    
                    if (UnityEditor.PrefabUtility.IsPartOfPrefabInstance(selected))
                    {
                        var root = PrefabUtility.GetOutermostPrefabInstanceRoot(selected);
                        PrefabUtility.UnpackPrefabInstance(root, PrefabUnpackMode.Completely, UnityEditor.InteractionMode.AutomatedAction);
                    }
                }
