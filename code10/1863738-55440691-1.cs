cs
using System.Threading.Tasks;
void Start () {
    DevideRecursive( ..params.. );
}
private async void DevideRecursive(int pMinX, int pMaxX, int pMinY, int pMaxY) {
    // code
    while (!Input.GetKeyDown(KeyCode.Space))
        await Task.Yield ();
    doNextStep = false;
    // code
    DevideRecursive( .. params .. );
    return
}
More infomation on aysnc in Unity [here][1].
An IEnumerator could also be used, which gives you the option to control the function externally.
  [1]: http://www.stevevermeulen.com/index.php/2017/09/using-async-await-in-unity3d-2017/
