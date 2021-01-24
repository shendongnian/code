cs
using System.Threading.Tasks;
public bool doNextStep;
void Start () {
    await DevideRecursive( ..params.. );
}
private async void DevideRecursive(int pMinX, int pMaxX, int pMinY, int pMaxY) {
    // code
    while (!doNextStep)
        await Task.Yield ();
    doNextStep = false;
    // code
    DevideRecursive( .. params .. );
    return
}
