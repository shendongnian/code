csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System;
using System.IO;
public class BuildScript
{
    //Script is called after the building process, BuildTarget and string pathToBuiltProject are mandatory arguments
    [PostProcessBuildAttribute(1)]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
        //Give the user a file folder pop-up asking for the location you wish to save the file to
        string path = EditorUtility.SaveFolderPanel("Save location", "", "");
        //Alternative you can also just hardcode the path..
        //string path = "C:/Dev/Unity/MyProject/MyBuilds/
        //Get the current datetime and convert it to a string with some explanatory text
        string date = string.Format("Build date: {0}", DateTime.Now.ToString());
        //Write the date to a text file called "BuildDate.txt" at the selected location
        File.WriteAllText(path + "BuildDate.txt", date);
    }
}
Now after building the "BuildDate.txt" file will be included in the selected location, containing the DateTime of the build (e.g `Build date: 19/02/2020 20:29:30`)
  [1]: https://docs.unity3d.com/Manual/BuildPlayerPipeline.html
