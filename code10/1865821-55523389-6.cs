    #if UNITY_EDITOR
        private void AddListsToBuildSettings()
        {
            var editorBuildSettingsScenes = new List<EditorBuildSettingsScene>
            {
                // Pre-add the current Scene
                new EditorBuildSettingsScene(SceneManager.GetActiveScene().path, true)
            };
    
            // Add all scenes in ScenePaths to the EditorBuildSettings
            foreach (var scene in ScenePaths)
            {
                // ignore unsaved scenes
                if (string.IsNullOrEmpty(scene?.Path)) continue;
    
                // skip if scene already in buildSettings
                if (editorBuildSettingsScenes.Any(s => string.Equals(s.path, scene))) continue;
    
                editorBuildSettingsScenes.Add(new EditorBuildSettingsScene(scene.Path, true));
            }
    
            // Set the Build Settings window Scene list
            EditorBuildSettings.scenes = editorBuildSettingsScenes.ToArray();
        }
    #endif
