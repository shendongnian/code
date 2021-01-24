bool success = true;
foreach (var item in Pictures)
{
    if (item.rotation.z != 0)
    {
        success = false;
    }
}
if (success) {
    YouWin = true;
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex + 1);
}
Or using Linq:
bool won = pictures.TrueForAll(x=> x.rotation.z == 0);
