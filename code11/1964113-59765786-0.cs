[MenuItem("GameObject/Camera", priority = 11)]
static void CreateCamera(MenuCommand menuCommand)
{
    var parent = menuCommand.context as GameObject;
    Place(ObjectFactory.CreateGameObject("Camera", typeof(Camera), typeof(AudioListener)), parent);
}
  [1]: https://github.com/Unity-Technologies/UnityCsReference/blob/32bd3a1c008265df4cd53b556446fab60f964834/Editor/Mono/Commands/GOCreationCommands.cs
